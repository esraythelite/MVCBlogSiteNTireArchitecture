using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Entities;
using WebUI.Models.ViewModels;
using System.IO;
using BusinessLogicLayer.Services.Abstract;

namespace WebUI.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDetailService userDetailService;
        private readonly IUserService userService;

        public UsersController(ApplicationDbContext context, IUserDetailService userDetailService, IUserService userService)
        {
            _context = context;
            this.userDetailService = userDetailService;
            this.userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Users.Include(u => u.UserDetail);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.UserDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            UserAndDetailVM userAndDetailVM = new UserAndDetailVM();
           
            return View(userAndDetailVM);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserAndDetailVM userAndDetailVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    TempData["Message"] = "Kullanıcı kaydetme işlemi hatalı";
            //    return View();

            //}
            if (userAndDetailVM.UserDetail.UserPhoto!=null)
            {
                string ticks = DateTime.Now.Ticks.ToString(); 
                var path = Directory.GetCurrentDirectory() + @"\wwwroot\images" + ticks + Path.GetExtension(userAndDetailVM.UserDetail.UserPhoto.FileName); 
                using (var stream = new FileStream(path, FileMode.Create)) 
                {
                    userAndDetailVM.UserDetail.UserPhoto.CopyTo(stream); 
                }
                userAndDetailVM.UserDetail.UserPhotoPath = @"\images" + ticks + Path.GetExtension(userAndDetailVM.UserDetail.UserPhoto.FileName);
            }
            userDetailService.Add(userAndDetailVM.UserDetail);
            
            userService.Add(userAndDetailVM.User);

            userAndDetailVM.User.UserDetailId = userAndDetailVM.UserDetail.Id;

            userService.Update(userAndDetailVM.User);
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "Id", "UserFirstName", user.UserDetailId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserDetailId,UserMail,UserName,Password,Id")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "Id", "UserFirstName", user.UserDetailId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.UserDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
