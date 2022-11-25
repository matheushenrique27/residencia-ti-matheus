using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LigaBankMVC.Data;
using LigaBankMVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Drawing;

namespace LigaBankMVC.Controllers
{
    public class ContasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Guid? id)
        {
            var conta = await _context.Conta.FindAsync(id);
            if (id == null || conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        [Authorize]
        public async Task<IActionResult> Details()
        {
            var userEmail = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);

            if (user == null || _context.Conta == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta
                .FirstOrDefaultAsync(m => m.UsuarioId == Guid.Parse(user.Id));
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Conta conta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = conta.Id });
            }
            return View();
        }

        public async Task<IActionResult> DepositoNoSaldo(Guid? id, Decimal saldoDaConta)
        {
            if (saldoDaConta < 0) { throw new Exception("Não é possível depositar valores negativos."); }

            else if (saldoDaConta == 0) { throw new Exception("Deposite algum valor acima de 0."); }

            else
            {
                var conta = await _context.Conta.FindAsync(id);
                conta.SaldoDaConta += saldoDaConta;
                _context.Update(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Contas");
            }

        }

        public async Task<IActionResult> SaqueDoSaldo(Guid? id, Decimal saldoDaconta)
        {
            var conta = await _context.Conta.FindAsync(id);

            if (conta.SaldoDaConta == 0) { throw new Exception("Saldo insuficiente!"); }

            else if (conta.SaldoDaConta < saldoDaconta) { throw new Exception("Você só pode sacar no momento R$ " + conta.SaldoDaConta + "."); }

            else
            {
                conta.SaldoDaConta -= saldoDaconta;
                _context.Update(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Contas");
            }
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Conta == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            return View(conta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("NumeroDaAgencia,SaldoDaConta,Id")] Conta conta)
        {
            if (id != conta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.Id))
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
            return View(conta);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Conta == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Conta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conta'  is null.");
            }
            var conta = await _context.Conta.FindAsync(id);
            if (conta != null)
            {
                _context.Conta.Remove(conta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaExists(Guid id)
        {
            return _context.Conta.Any(e => e.Id == id);
        }
    }
}