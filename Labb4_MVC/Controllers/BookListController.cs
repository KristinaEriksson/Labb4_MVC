using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb4_MVC.Data;
using Labb4_MVC.Models;
using Microsoft.IdentityModel.Tokens;

namespace Labb4_MVC.Controllers
{
    public class BookListController : Controller
    {
        private readonly ForzaLibraryDbContext _context;

        public BookListController(ForzaLibraryDbContext context)
        {
            _context = context;
        }

        // GET: BookList
        public async Task<IActionResult> Index()
        {
            var forzaLibraryDbContext = _context.BooksLists.Include(b => b.Books).Include(b => b.Customers);
            return View(await forzaLibraryDbContext.ToListAsync());
        }

        // GET: Search a specific customer
        public async Task<IActionResult> Search(string SearchCustomer)
        {
            var customer = await _context.Customers
                .Include(bl => bl.BookLists)
                .ThenInclude(b => b.Books)
                .Where(c => c.FirstName.Contains(SearchCustomer))
                .ToListAsync();
                
            return View("Index",customer.SelectMany(c => c.BookLists));
        }

        // GET: BookList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BooksLists == null)
            {
                return NotFound();
            }

            var bookList = await _context.BooksLists
                .Include(b => b.Books)
                .Include(b => b.Customers)
                .FirstOrDefaultAsync(m => m.BookListID == id);
            if (bookList == null)
            {
                return NotFound();
            }

            return View(bookList);
        }

        // GET: BookList/Create
        public IActionResult Create()
        {
            ViewData["FK_BookID"] = new SelectList(_context.Books, "BookID", "BookDisplay");
            ViewData["FK_CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName");
            return View();
        }

        // POST: BookList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookListID,BorrowingDate,ReturnedAt,FK_CustomerID,FK_BookID")] BookList bookList)
        {
            if (ModelState.IsValid)
            {
                bookList.ReturningDate = bookList.BorrowingDate.AddDays(14);
                _context.Add(bookList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_BookID"] = new SelectList(_context.Books, "BookID", "BookDisplay", bookList.FK_BookID);
            ViewData["FK_CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", bookList.FK_CustomerID);
            return View(bookList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Returned(int bookListID, bool returned)
        {
            var book = await _context.BooksLists.FindAsync(bookListID);

            if (book == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                book.Returned = returned;

                if (returned)
                {
                    book.ReturnedAt = DateTime.Now;
                }
                else
                {
                    book.ReturnedAt = DateTime.MinValue;
                }

                _context.Update(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: BookList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BooksLists == null)
            {
                return NotFound();
            }

            var bookList = await _context.BooksLists.FindAsync(id);
            if (bookList == null)
            {
                return NotFound();
            }
            ViewData["FK_BookID"] = new SelectList(_context.Books, "BookID", "BookDisplay", bookList.FK_BookID);
            ViewData["FK_CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", bookList.FK_CustomerID);
            return View(bookList);
        }

        // POST: BookList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookListID,BorrowingDate,ReturningDate,Returned,ReturnedAt,FK_CustomerID,FK_BookID")] BookList bookList)
        {
            if (id != bookList.BookListID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (bookList.ReturnedAt > bookList.ReturningDate)
                    {
                        bookList.IsPastReturningDate = true;
                    } 
                    else
                    {
                        bookList.IsPastReturningDate = false;
                    }

                    if (bookList.Returned && bookList.ReturnedAt == DateTime.MinValue)
                    {
                        bookList.ReturnedAt = DateTime.Now;
                        
                    }
                    
                    _context.Update(bookList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookListExists(bookList.BookListID))
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
            ViewData["FK_BookID"] = new SelectList(_context.Books, "BookID", "BookDisplay", bookList.FK_BookID);
            ViewData["FK_CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", bookList.FK_CustomerID);
            return View(bookList);
        }

        

        // GET: BookList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BooksLists == null)
            {
                return NotFound();
            }

            var bookList = await _context.BooksLists
                .Include(b => b.Books)
                .Include(b => b.Customers)
                .FirstOrDefaultAsync(m => m.BookListID == id);
            if (bookList == null)
            {
                return NotFound();
            }

            return View(bookList);
        }

        // POST: BookList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BooksLists == null)
            {
                return Problem("Entity set 'ForzaLibraryDbContext.BooksLists'  is null.");
            }
            var bookList = await _context.BooksLists.FindAsync(id);
            if (bookList != null)
            {
                _context.BooksLists.Remove(bookList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookListExists(int id)
        {
          return (_context.BooksLists?.Any(e => e.BookListID == id)).GetValueOrDefault();
        }
    }
}
