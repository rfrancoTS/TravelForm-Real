using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using TravelRequest.Data;
using TravelRequest.Models;
using static NuGet.Packaging.PackagingConstants;
using Telerik.SvgIcons;
using Microsoft.AspNetCore.Builder;

namespace TravelRequest.Pages.Home
{
    public class IndexModel : PageModel
    {

        private readonly TravelRequest.Data.ApplicationDbContext _context;
        public IndexModel(TravelRequest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TsiTravelModel> TravelModels { get; set; } = default!;

        public async Task OnGetAsync()
        {
            TravelModels = await _context.TsiTravelModels.ToListAsync();
        }

        public async Task<IActionResult> OnPostUpdate(TsiTravelModel travelModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(travelModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelModelExists(travelModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TravelModelExists(int id)
        {
            return _context.TsiTravelModels.Any(e => e.Id == id);
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelModel = await _context.TsiTravelModels.FindAsync(id);

            if (travelModel != null)
            {
                _context.TsiTravelModels.Remove(travelModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostCreate(TsiTravelModel travelModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TsiTravelModels.Add(travelModel);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch
            {
                ViewData["Message"] = "Unable to save. There might be a duplication or other database error.";
                return Page();
            }
        }

        public async Task<ActionResult> OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            var TsiTravelModels = await _context.TsiTravelModels.ToListAsync();
            return new JsonResult(TsiTravelModels.ToDataSourceResult(request));
        }
    }
}