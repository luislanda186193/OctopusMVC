using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Controllers
{
    public class LadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LadasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ladas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ladas.Include(l => l.Region).AsNoTracking().OrderBy(s => s.RegionId).Skip(0).Take(10);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ladas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lada = await _context.Ladas
                .Include(l => l.Region).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lada == null)
            {
                return NotFound();
            }

            return View(lada);
        }

        // GET: Ladas/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName");
            return View();
        }

        // POST: Ladas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LadaName,RegionId")] Lada lada)
        {
            if (ModelState.IsValid)
            {
               // _context.AddRange(ladasInit);
                _context.Add(lada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName", lada.RegionId);
            return View(lada);
        }

        // GET: Ladas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lada = await _context.Ladas.FindAsync(id);
            if (lada == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName", lada.RegionId);
            return View(lada);
        }

        // POST: Ladas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LadaName,RegionId")] Lada lada)
        {
            if (id != lada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LadaExists(lada.Id))
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
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName", lada.RegionId);
            return View(lada);
        }

        // GET: Ladas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lada = await _context.Ladas
                .Include(l => l.Region).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lada == null)
            {
                return NotFound();
            }

            return View(lada);
        }

        // POST: Ladas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lada = await _context.Ladas.FindAsync(id);
            _context.Ladas.Remove(lada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LadaExists(int id)
        {
            return _context.Ladas.Any(e => e.Id == id);
        }
        public List<Lada> ladasInit
        {
            get
            {
                return new List<Lada>() {
                    new Lada(){LadaName="612",RegionId = 1 },
                    new Lada(){LadaName="613",RegionId = 1 },
                    new Lada(){LadaName="615",RegionId = 1 },
                    new Lada(){LadaName="616",RegionId = 1 },
                    new Lada(){LadaName="624",RegionId = 1 },
                    new Lada(){LadaName="646",RegionId = 1 },
                    new Lada(){LadaName="653",RegionId = 1 },
                    new Lada(){LadaName="658",RegionId = 1 },
                    new Lada(){LadaName="661",RegionId = 1 },
                    new Lada(){LadaName="664",RegionId = 1 },
                    new Lada(){LadaName="665",RegionId = 1 },
                    new Lada(){LadaName="686",RegionId = 1 },

                    new Lada(){LadaName="623",RegionId = 2 },
                    new Lada(){LadaName="622",RegionId = 2 },
                    new Lada(){LadaName="631",RegionId = 2 },
                    new Lada(){LadaName="632",RegionId = 2 },
                    new Lada(){LadaName="633",RegionId = 2 },
                    new Lada(){LadaName="634",RegionId = 2 },
                    new Lada(){LadaName="637",RegionId = 2 },
                    new Lada(){LadaName="638",RegionId = 2 },
                    new Lada(){LadaName="641",RegionId = 2 },
                    new Lada(){LadaName="642",RegionId = 2 },
                    new Lada(){LadaName="643",RegionId = 2 },
                    new Lada(){LadaName="644",RegionId = 2 },
                    new Lada(){LadaName="645",RegionId = 2 },
                    new Lada(){LadaName="647",RegionId = 2 },
                    new Lada(){LadaName="651",RegionId = 2 },
                    new Lada(){LadaName="662",RegionId = 2 },
                    new Lada(){LadaName="667",RegionId = 2 },
                    new Lada(){LadaName="668",RegionId = 2 },
                    new Lada(){LadaName="669",RegionId = 2 },
                    new Lada(){LadaName="672",RegionId = 2 },
                    new Lada(){LadaName="673",RegionId = 2 },
                    new Lada(){LadaName="687",RegionId = 2 },
                    new Lada(){LadaName="694",RegionId = 2 },
                    new Lada(){LadaName="695",RegionId = 2 },
                    new Lada(){LadaName="696",RegionId = 2 },
                    new Lada(){LadaName="697",RegionId = 2 },
                    new Lada(){LadaName="698",RegionId = 2 },

                    new Lada(){LadaName="614",RegionId = 3 },
                    new Lada(){LadaName="618",RegionId = 3 },
                    new Lada(){LadaName="621",RegionId = 3 },
                    new Lada(){LadaName="625",RegionId = 3 },
                    new Lada(){LadaName="626",RegionId = 3 },
                    new Lada(){LadaName="627",RegionId = 3 },
                    new Lada(){LadaName="628",RegionId = 3 },
                    new Lada(){LadaName="629",RegionId = 3 },
                    new Lada(){LadaName="635",RegionId = 3 },
                    new Lada(){LadaName="636",RegionId = 3 },
                    new Lada(){LadaName="639",RegionId = 3 },
                    new Lada(){LadaName="648",RegionId = 3 },
                    new Lada(){LadaName="649",RegionId = 3 },
                    new Lada(){LadaName="652",RegionId = 3 },
                    new Lada(){LadaName="656",RegionId = 3 },
                    new Lada(){LadaName="659",RegionId = 3 },
                    new Lada(){LadaName="671",RegionId = 3 },
                    new Lada(){LadaName="674",RegionId = 3 },
                    new Lada(){LadaName="675",RegionId = 3 },
                    new Lada(){LadaName="676",RegionId = 3 },
                    new Lada(){LadaName="677",RegionId = 3 },
                    new Lada(){LadaName="871",RegionId = 3 },
                    new Lada(){LadaName="872",RegionId = 3 },

                    new Lada(){LadaName="842112",RegionId = 3 },

                    new Lada(){LadaName="81",RegionId = 4 },

                    new Lada(){LadaName="481",RegionId = 4 },
                    new Lada(){LadaName="821",RegionId = 4 },
                    new Lada(){LadaName="823",RegionId = 4 },
                    new Lada(){LadaName="824",RegionId = 4 },
                    new Lada(){LadaName="825",RegionId = 4 },
                    new Lada(){LadaName="826",RegionId = 4 },
                    new Lada(){LadaName="828",RegionId = 4 },
                    new Lada(){LadaName="829",RegionId = 4 },
                    new Lada(){LadaName="831",RegionId = 4 },
                    new Lada(){LadaName="832",RegionId = 4 },
                    new Lada(){LadaName="833",RegionId = 4 },
                    new Lada(){LadaName="834",RegionId = 4 },
                    new Lada(){LadaName="835",RegionId = 4 },
                    new Lada(){LadaName="836",RegionId = 4 },
                    new Lada(){LadaName="841",RegionId = 4 },
                    new Lada(){LadaName="843",RegionId = 4 },
                    new Lada(){LadaName="844",RegionId = 4 },
                    new Lada(){LadaName="845",RegionId = 4 },
                    new Lada(){LadaName="846",RegionId = 4 },
                    new Lada(){LadaName="861",RegionId = 4 },
                    new Lada(){LadaName="862",RegionId = 4 },
                    new Lada(){LadaName="864",RegionId = 4 },
                    new Lada(){LadaName="866",RegionId = 4 },
                    new Lada(){LadaName="867",RegionId = 4 },
                    new Lada(){LadaName="868",RegionId = 4 },
                    new Lada(){LadaName="869",RegionId = 4 },
                    new Lada(){LadaName="873",RegionId = 4 },
                    new Lada(){LadaName="877",RegionId = 4 },
                    new Lada(){LadaName="878",RegionId = 4 },
                    new Lada(){LadaName="891",RegionId = 4 },
                    new Lada(){LadaName="892",RegionId = 4 },
                    new Lada(){LadaName="894",RegionId = 4 },
                    new Lada(){LadaName="897",RegionId = 4 },
                    new Lada(){LadaName="899",RegionId = 4 },

                    new Lada(){LadaName="8424",RegionId = 4 },
                    new Lada(){LadaName="8425",RegionId = 4 },
                    new Lada(){LadaName="8426",RegionId = 4 },
                    new Lada(){LadaName="8427",RegionId = 4 },
                    new Lada(){LadaName="8428",RegionId = 4 },
                    new Lada(){LadaName="8429",RegionId = 4 },

                    new Lada(){LadaName="488116",RegionId = 4 },
                    new Lada(){LadaName="842100",RegionId = 4 },
                    new Lada(){LadaName="842101",RegionId = 4 },

                    new Lada(){LadaName="4821041",RegionId = 4 },
                    new Lada(){LadaName="4821042",RegionId = 4 },
                    new Lada(){LadaName="4821043",RegionId = 4 },
                    new Lada(){LadaName="4881095",RegionId = 4 },
                    new Lada(){LadaName="4881100",RegionId = 4 },
                    new Lada(){LadaName="4881106",RegionId = 4 },
                    new Lada(){LadaName="4881107",RegionId = 4 },

                    new Lada(){LadaName="4888890",RegionId = 4 },
                    new Lada(){LadaName="4888891",RegionId = 4 },
                    new Lada(){LadaName="4888892",RegionId = 4 },
                    new Lada(){LadaName="4888899",RegionId = 4 },
                    new Lada(){LadaName="8421080",RegionId = 4 },
                    new Lada(){LadaName="8421081",RegionId = 4 },
                    new Lada(){LadaName="8421082",RegionId = 4 },
                    new Lada(){LadaName="8421083",RegionId = 4 },
                    new Lada(){LadaName="8421085",RegionId = 4 },
                    new Lada(){LadaName="8421086",RegionId = 4 },
                    new Lada(){LadaName="8421087",RegionId = 4 },
                    new Lada(){LadaName="8421088",RegionId = 4 },
                    new Lada(){LadaName="8421089",RegionId = 4 },

                    new Lada(){LadaName="4371031",RegionId = 5 },
                    new Lada(){LadaName="4371032",RegionId = 5 },
                    new Lada(){LadaName="4371033",RegionId = 5 },
                    new Lada(){LadaName="4371034",RegionId = 5 },
                    new Lada(){LadaName="4381042",RegionId = 5 },
                    new Lada(){LadaName="4381043",RegionId = 5 },
                    new Lada(){LadaName="4381044",RegionId = 5 },
                    new Lada(){LadaName="4381045",RegionId = 5 },
                    new Lada(){LadaName="4381046",RegionId = 5 },
                    new Lada(){LadaName="4381047",RegionId = 5 },
                    new Lada(){LadaName="4381048",RegionId = 5 },
                    new Lada(){LadaName="4381049",RegionId = 5 },
                    new Lada(){LadaName="4381130",RegionId = 5 },
                    new Lada(){LadaName="4381131",RegionId = 5 },
                    new Lada(){LadaName="4381133",RegionId = 5 },
                    new Lada(){LadaName="4381134",RegionId = 5 },
                    new Lada(){LadaName="4381135",RegionId = 5 },
                    new Lada(){LadaName="4381136",RegionId = 5 },
                    new Lada(){LadaName="4381137",RegionId = 5 },
                    new Lada(){LadaName="4381138",RegionId = 5 },
                    new Lada(){LadaName="4381139",RegionId = 5 },
                    new Lada(){LadaName="4381115",RegionId = 5 },
                    new Lada(){LadaName="4381116",RegionId = 5 },
                    new Lada(){LadaName="4381117",RegionId = 5 },
                    new Lada(){LadaName="4381118",RegionId = 5 },
                    new Lada(){LadaName="4381119",RegionId = 5 },
                    new Lada(){LadaName="4381000",RegionId = 5 },
                    new Lada(){LadaName="4381001",RegionId = 5 },
                    new Lada(){LadaName="4381002",RegionId = 5 },
                    new Lada(){LadaName="4381003",RegionId = 5 },
                    new Lada(){LadaName="4381008",RegionId = 5 },
                    new Lada(){LadaName="4381009",RegionId = 5 },

                    new Lada(){LadaName="438101",RegionId = 5 },
                    new Lada(){LadaName="438102",RegionId = 5 },
                    new Lada(){LadaName="438103",RegionId = 5 },
                    new Lada(){LadaName="438105",RegionId = 5 },
                    new Lada(){LadaName="438106",RegionId = 5 },
                    new Lada(){LadaName="438107",RegionId = 5 },
                    new Lada(){LadaName="438108",RegionId = 5 },
                    new Lada(){LadaName="438109",RegionId = 5 },
                    new Lada(){LadaName="438112",RegionId = 5 },
                    new Lada(){LadaName="438114",RegionId = 5 },
                    new Lada(){LadaName="438115",RegionId = 5 },
                    new Lada(){LadaName="438116",RegionId = 5 },
                    new Lada(){LadaName="438117",RegionId = 5 },
                    new Lada(){LadaName="438118",RegionId = 5 },
                    new Lada(){LadaName="438119",RegionId = 5 },
                    new Lada(){LadaName="499101",RegionId = 5 },

                    new Lada(){LadaName="4380",RegionId = 5 },
                    new Lada(){LadaName="4382",RegionId = 5 },
                    new Lada(){LadaName="4383",RegionId = 5 },
                    new Lada(){LadaName="4384",RegionId = 5 },
                    new Lada(){LadaName="4385",RegionId = 5 },
                    new Lada(){LadaName="4386",RegionId = 5 },
                    new Lada(){LadaName="4387",RegionId = 5 },
                    new Lada(){LadaName="4388",RegionId = 5 },
                    new Lada(){LadaName="4389",RegionId = 5 },

                    new Lada(){LadaName="311",RegionId = 5 },
                    new Lada(){LadaName="312",RegionId = 5 },
                    new Lada(){LadaName="313",RegionId = 5 },
                    new Lada(){LadaName="314",RegionId = 5 },
                    new Lada(){LadaName="315",RegionId = 5 },
                    new Lada(){LadaName="316",RegionId = 5 },
                    new Lada(){LadaName="317",RegionId = 5 },
                    new Lada(){LadaName="319",RegionId = 5 },
                    new Lada(){LadaName="321",RegionId = 5 },
                    new Lada(){LadaName="322",RegionId = 5 },
                    new Lada(){LadaName="323",RegionId = 5 },
                    new Lada(){LadaName="324",RegionId = 5 },
                    new Lada(){LadaName="325",RegionId = 5 },
                    new Lada(){LadaName="326",RegionId = 5 },
                    new Lada(){LadaName="327",RegionId = 5 },
                    new Lada(){LadaName="328",RegionId = 5 },
                    new Lada(){LadaName="329",RegionId = 5 },
                    new Lada(){LadaName="341",RegionId = 5 },
                    new Lada(){LadaName="342",RegionId = 5 },
                    new Lada(){LadaName="343",RegionId = 5 },
                    new Lada(){LadaName="344",RegionId = 5 },
                    new Lada(){LadaName="345",RegionId = 5 },
                    new Lada(){LadaName="347",RegionId = 5 },
                    new Lada(){LadaName="348",RegionId = 5 },
                    new Lada(){LadaName="349",RegionId = 5 },
                    new Lada(){LadaName="351",RegionId = 5 },
                    new Lada(){LadaName="352",RegionId = 5 },
                    new Lada(){LadaName="353",RegionId = 5 },
                    new Lada(){LadaName="354",RegionId = 5 },
                    new Lada(){LadaName="355",RegionId = 5 },
                    new Lada(){LadaName="356",RegionId = 5 },
                    new Lada(){LadaName="357",RegionId = 5 },
                    new Lada(){LadaName="358",RegionId = 5 },
                    new Lada(){LadaName="359",RegionId = 5 },
                    new Lada(){LadaName="371",RegionId = 5 },
                    new Lada(){LadaName="372",RegionId = 5 },
                    new Lada(){LadaName="373",RegionId = 5 },
                    new Lada(){LadaName="374",RegionId = 5 },
                    new Lada(){LadaName="375",RegionId = 5 },
                    new Lada(){LadaName="376",RegionId = 5 },
                    new Lada(){LadaName="377",RegionId = 5 },
                    new Lada(){LadaName="378",RegionId = 5 },
                    new Lada(){LadaName="381",RegionId = 5 },
                    new Lada(){LadaName="382",RegionId = 5 },
                    new Lada(){LadaName="383",RegionId = 5 },
                    new Lada(){LadaName="384",RegionId = 5 },
                    new Lada(){LadaName="385",RegionId = 5 },
                    new Lada(){LadaName="386",RegionId = 5 },
                    new Lada(){LadaName="387",RegionId = 5 },
                    new Lada(){LadaName="388",RegionId = 5 },
                    new Lada(){LadaName="389",RegionId = 5 },
                    new Lada(){LadaName="391",RegionId = 5 },
                    new Lada(){LadaName="392",RegionId = 5 },
                    new Lada(){LadaName="393",RegionId = 5 },
                    new Lada(){LadaName="394",RegionId = 5 },
                    new Lada(){LadaName="395",RegionId = 5 },
                    new Lada(){LadaName="422",RegionId = 5 },
                    new Lada(){LadaName="423",RegionId = 5 },
                    new Lada(){LadaName="424",RegionId = 5 },
                    new Lada(){LadaName="425",RegionId = 5 },
                    new Lada(){LadaName="426",RegionId = 5 },
                    new Lada(){LadaName="431",RegionId = 5 },
                    new Lada(){LadaName="434",RegionId = 5 },
                    new Lada(){LadaName="435",RegionId = 5 },
                    new Lada(){LadaName="436",RegionId = 5 },
                    new Lada(){LadaName="440",RegionId = 5 },
                    new Lada(){LadaName="443",RegionId = 5 },
                    new Lada(){LadaName="447",RegionId = 5 },
                    new Lada(){LadaName="451",RegionId = 5 },
                    new Lada(){LadaName="452",RegionId = 5 },
                    new Lada(){LadaName="453",RegionId = 5 },
                    new Lada(){LadaName="454",RegionId = 5 },
                    new Lada(){LadaName="455",RegionId = 5 },
                    new Lada(){LadaName="459",RegionId = 5 },
                    new Lada(){LadaName="471",RegionId = 5 },
                    new Lada(){LadaName="715",RegionId = 5 },
                    new Lada(){LadaName="753",RegionId = 5 },
                    new Lada(){LadaName="786",RegionId = 5 },

                    new Lada(){LadaName="33",RegionId = 5 },



                    new Lada(){LadaName="346",RegionId = 6 },
                    new Lada(){LadaName="411",RegionId = 6 },
                    new Lada(){LadaName="412",RegionId = 6 },
                    new Lada(){LadaName="413",RegionId = 6 },
                    new Lada(){LadaName="414",RegionId = 6 },
                    new Lada(){LadaName="415",RegionId = 6 },
                    new Lada(){LadaName="417",RegionId = 6 },
                    new Lada(){LadaName="418",RegionId = 6 },
                    new Lada(){LadaName="419",RegionId = 6 },
                    new Lada(){LadaName="421",RegionId = 6 },
                    new Lada(){LadaName="427",RegionId = 6 },
                    new Lada(){LadaName="428",RegionId = 6 },
                    new Lada(){LadaName="429",RegionId = 6 },
                    new Lada(){LadaName="432",RegionId = 6 },
                    new Lada(){LadaName="433",RegionId = 6 },
                    new Lada(){LadaName="441",RegionId = 6 },
                    new Lada(){LadaName="442",RegionId = 6 },
                    new Lada(){LadaName="444",RegionId = 6 },
                    new Lada(){LadaName="445",RegionId = 6 },
                    new Lada(){LadaName="448",RegionId = 6 },
                    new Lada(){LadaName="449",RegionId = 6 },
                    new Lada(){LadaName="456",RegionId = 6 },
                    new Lada(){LadaName="457",RegionId = 6 },
                    new Lada(){LadaName="458",RegionId = 6 },
                    new Lada(){LadaName="461",RegionId = 6 },
                    new Lada(){LadaName="462",RegionId = 6 },
                    new Lada(){LadaName="463",RegionId = 6 },
                    new Lada(){LadaName="464",RegionId = 6 },
                    new Lada(){LadaName="465",RegionId = 6 },
                    new Lada(){LadaName="466",RegionId = 6 },
                    new Lada(){LadaName="467",RegionId = 6 },
                    new Lada(){LadaName="468",RegionId = 6 },
                    new Lada(){LadaName="469",RegionId = 6 },
                    new Lada(){LadaName="472",RegionId = 6 },
                    new Lada(){LadaName="473",RegionId = 6 },
                    new Lada(){LadaName="474",RegionId = 6 },
                    new Lada(){LadaName="475",RegionId = 6 },
                    new Lada(){LadaName="476",RegionId = 6 },
                    new Lada(){LadaName="477",RegionId = 6 },
                    new Lada(){LadaName="478",RegionId = 6 },
                    new Lada(){LadaName="483",RegionId = 6 },
                    new Lada(){LadaName="485",RegionId = 6 },
                    new Lada(){LadaName="486",RegionId = 6 },
                    new Lada(){LadaName="487",RegionId = 6 },
                    new Lada(){LadaName="489",RegionId = 6 },
                    new Lada(){LadaName="492",RegionId = 6 },
                    new Lada(){LadaName="493",RegionId = 6 },
                    new Lada(){LadaName="494",RegionId = 6 },
                    new Lada(){LadaName="495",RegionId = 6 },
                    new Lada(){LadaName="496",RegionId = 6 },
                    new Lada(){LadaName="498",RegionId = 6 },


                    new Lada(){LadaName="4882",RegionId = 6 },
                    new Lada(){LadaName="4883",RegionId = 6 },
                    new Lada(){LadaName="4884",RegionId = 6 },
                    new Lada(){LadaName="4885",RegionId = 6 },
                    new Lada(){LadaName="4886",RegionId = 6 },
                    new Lada(){LadaName="4887",RegionId = 6 },
                    new Lada(){LadaName="4822",RegionId = 6 },
                    new Lada(){LadaName="4823",RegionId = 6 },
                    new Lada(){LadaName="4824",RegionId = 6 },
                    new Lada(){LadaName="4825",RegionId = 6 },
                    new Lada(){LadaName="4826",RegionId = 6 },
                    new Lada(){LadaName="4827",RegionId = 6 },
                    new Lada(){LadaName="4828",RegionId = 6 },
                    new Lada(){LadaName="4829",RegionId = 6 },
                    new Lada(){LadaName="4372",RegionId = 6 },
                    new Lada(){LadaName="4373",RegionId = 6 },
                    new Lada(){LadaName="4374",RegionId = 6 },

                    new Lada(){LadaName="48211",RegionId = 6 },
                    new Lada(){LadaName="48212",RegionId = 6 },
                    new Lada(){LadaName="48213",RegionId = 6 },
                    new Lada(){LadaName="48214",RegionId = 6 },
                    new Lada(){LadaName="48215",RegionId = 6 },
                    new Lada(){LadaName="48216",RegionId = 6 },
                    new Lada(){LadaName="48217",RegionId = 6 },
                    new Lada(){LadaName="48218",RegionId = 6 },
                    new Lada(){LadaName="48219",RegionId = 6 },
                    new Lada(){LadaName="43711",RegionId = 6 },
                    new Lada(){LadaName="43712",RegionId = 6 },
                    new Lada(){LadaName="43713",RegionId = 6 },
                    new Lada(){LadaName="43714",RegionId = 6 },
                    new Lada(){LadaName="43715",RegionId = 6 },
                    new Lada(){LadaName="43716",RegionId = 6 },
                    new Lada(){LadaName="43717",RegionId = 6 },
                    new Lada(){LadaName="43718",RegionId = 6 },
                    new Lada(){LadaName="43719",RegionId = 6 },

                    new Lada(){LadaName="842109",RegionId = 6 },
                    new Lada(){LadaName="499100",RegionId = 6 },
                    new Lada(){LadaName="499102",RegionId = 6 },
                    new Lada(){LadaName="499103",RegionId = 6 },
                    new Lada(){LadaName="842102",RegionId = 6 },
                    new Lada(){LadaName="842103",RegionId = 6 },
                    new Lada(){LadaName="842104",RegionId = 6 },
                    new Lada(){LadaName="488883",RegionId = 6 },
                    new Lada(){LadaName="488884",RegionId = 6 },
                    new Lada(){LadaName="488111",RegionId = 6 },
                    new Lada(){LadaName="488112",RegionId = 6 },
                    new Lada(){LadaName="488113",RegionId = 6 },
                    new Lada(){LadaName="488114",RegionId = 6 },
                    new Lada(){LadaName="488115",RegionId = 6 },
                    new Lada(){LadaName="488117",RegionId = 6 },
                    new Lada(){LadaName="488118",RegionId = 6 },
                    new Lada(){LadaName="488119",RegionId = 6 },
                    new Lada(){LadaName="488885",RegionId = 6 },
                    new Lada(){LadaName="488886",RegionId = 6 },
                    new Lada(){LadaName="488100",RegionId = 6 },
                    new Lada(){LadaName="488101",RegionId = 6 },
                    new Lada(){LadaName="488102",RegionId = 6 },
                    new Lada(){LadaName="488103",RegionId = 6 },
                    new Lada(){LadaName="488104",RegionId = 6 },
                    new Lada(){LadaName="488105",RegionId = 6 },
                    new Lada(){LadaName="488106",RegionId = 6 },
                    new Lada(){LadaName="488107",RegionId = 6 },
                    new Lada(){LadaName="488108",RegionId = 6 },
                    new Lada(){LadaName="482105",RegionId = 6 },
                    new Lada(){LadaName="482106",RegionId = 6 },
                    new Lada(){LadaName="482107",RegionId = 6 },
                    new Lada(){LadaName="482108",RegionId = 6 },
                    new Lada(){LadaName="482109",RegionId = 6 },
                    new Lada(){LadaName="482100",RegionId = 6 },
                    new Lada(){LadaName="482101",RegionId = 6 },
                    new Lada(){LadaName="482102",RegionId = 6 },
                    new Lada(){LadaName="482103",RegionId = 6 },
                    new Lada(){LadaName="437104",RegionId = 6 },
                    new Lada(){LadaName="437105",RegionId = 6 },
                    new Lada(){LadaName="437106",RegionId = 6 },
                    new Lada(){LadaName="437107",RegionId = 6 },
                    new Lada(){LadaName="437108",RegionId = 6 },
                    new Lada(){LadaName="437109",RegionId = 6 },
                    new Lada(){LadaName="437100",RegionId = 6 },
                    new Lada(){LadaName="437101",RegionId = 6 },
                    new Lada(){LadaName="437102",RegionId = 6 },

                    new Lada(){LadaName="4371035",RegionId = 6 },
                    new Lada(){LadaName="4371036",RegionId = 6 },
                    new Lada(){LadaName="4371037",RegionId = 6 },
                    new Lada(){LadaName="4371038",RegionId = 6 },
                    new Lada(){LadaName="4371039",RegionId = 6 },
                    new Lada(){LadaName="4381004",RegionId = 6 },
                    new Lada(){LadaName="4381005",RegionId = 6 },
                    new Lada(){LadaName="4381006",RegionId = 6 },
                    new Lada(){LadaName="4381007",RegionId = 6 },
                    new Lada(){LadaName="4381040",RegionId = 6 },
                    new Lada(){LadaName="4381041",RegionId = 6 },
                    new Lada(){LadaName="4381110",RegionId = 6 },
                    new Lada(){LadaName="4381111",RegionId = 6 },
                    new Lada(){LadaName="4381112",RegionId = 6 },
                    new Lada(){LadaName="4381113",RegionId = 6 },
                    new Lada(){LadaName="4381114",RegionId = 6 },
                    new Lada(){LadaName="4381132",RegionId = 6 },
                    new Lada(){LadaName="4821040",RegionId = 6 },
                    new Lada(){LadaName="4821044",RegionId = 6 },
                    new Lada(){LadaName="4821045",RegionId = 6 },
                    new Lada(){LadaName="4821046",RegionId = 6 },
                    new Lada(){LadaName="4821047",RegionId = 6 },
                    new Lada(){LadaName="4821048",RegionId = 6 },
                    new Lada(){LadaName="4821049",RegionId = 6 },
                    new Lada(){LadaName="4881090",RegionId = 6 },
                    new Lada(){LadaName="4881091",RegionId = 6 },
                    new Lada(){LadaName="4881092",RegionId = 6 },
                    new Lada(){LadaName="4881093",RegionId = 6 },
                    new Lada(){LadaName="4881094",RegionId = 6 },
                    new Lada(){LadaName="4881096",RegionId = 6 },
                    new Lada(){LadaName="4881097",RegionId = 6 },
                    new Lada(){LadaName="4881098",RegionId = 6 },
                    new Lada(){LadaName="4881099",RegionId = 6 },
                    new Lada(){LadaName="4881101",RegionId = 6 },
                    new Lada(){LadaName="4881102",RegionId = 6 },
                    new Lada(){LadaName="4881103",RegionId = 6 },
                    new Lada(){LadaName="4881104",RegionId = 6 },
                    new Lada(){LadaName="4881105",RegionId = 6 },
                    new Lada(){LadaName="4881108",RegionId = 6 },
                    new Lada(){LadaName="4881109",RegionId = 6 },
                    new Lada(){LadaName="8421084",RegionId = 6 },
                    new Lada(){LadaName="4888893",RegionId = 6 },
                    new Lada(){LadaName="4888894",RegionId = 6 },
                    new Lada(){LadaName="4888895",RegionId = 6 },
                    new Lada(){LadaName="4888896",RegionId = 6 },
                    new Lada(){LadaName="4888897",RegionId = 6 },
                    new Lada(){LadaName="4888898",RegionId = 6 },



                    new Lada(){LadaName="223",RegionId = 7 },
                    new Lada(){LadaName="224",RegionId = 7 },
                    new Lada(){LadaName="225",RegionId = 7 },
                    new Lada(){LadaName="226",RegionId = 7 },
                    new Lada(){LadaName="227",RegionId = 7 },
                    new Lada(){LadaName="228",RegionId = 7 },
                    new Lada(){LadaName="229",RegionId = 7 },
                    new Lada(){LadaName="231",RegionId = 7 },
                    new Lada(){LadaName="232",RegionId = 7 },
                    new Lada(){LadaName="233",RegionId = 7 },
                    new Lada(){LadaName="235",RegionId = 7 },
                    new Lada(){LadaName="236",RegionId = 7 },
                    new Lada(){LadaName="237",RegionId = 7 },
                    new Lada(){LadaName="238",RegionId = 7 },
                    new Lada(){LadaName="241",RegionId = 7 },
                    new Lada(){LadaName="243",RegionId = 7 },
                    new Lada(){LadaName="244",RegionId = 7 },
                    new Lada(){LadaName="245",RegionId = 7 },
                    new Lada(){LadaName="246",RegionId = 7 },
                    new Lada(){LadaName="247",RegionId = 7 },
                    new Lada(){LadaName="248",RegionId = 7 },
                    new Lada(){LadaName="249",RegionId = 7 },
                    new Lada(){LadaName="271",RegionId = 7 },
                    new Lada(){LadaName="272",RegionId = 7 },
                    new Lada(){LadaName="273",RegionId = 7 },
                    new Lada(){LadaName="274",RegionId = 7 },
                    new Lada(){LadaName="275",RegionId = 7 },
                    new Lada(){LadaName="276",RegionId = 7 },
                    new Lada(){LadaName="278",RegionId = 7 },
                    new Lada(){LadaName="279",RegionId = 7 },
                    new Lada(){LadaName="281",RegionId = 7 },
                    new Lada(){LadaName="282",RegionId = 7 },
                    new Lada(){LadaName="283",RegionId = 7 },
                    new Lada(){LadaName="284",RegionId = 7 },
                    new Lada(){LadaName="285",RegionId = 7 },
                    new Lada(){LadaName="287",RegionId = 7 },
                    new Lada(){LadaName="288",RegionId = 7 },
                    new Lada(){LadaName="294",RegionId = 7 },
                    new Lada(){LadaName="296",RegionId = 7 },
                    new Lada(){LadaName="297",RegionId = 7 },
                    new Lada(){LadaName="727",RegionId = 7 },
                    new Lada(){LadaName="732",RegionId = 7 },
                    new Lada(){LadaName="733",RegionId = 7 },
                    new Lada(){LadaName="736",RegionId = 7 },
                    new Lada(){LadaName="741",RegionId = 7 },
                    new Lada(){LadaName="742",RegionId = 7 },
                    new Lada(){LadaName="744",RegionId = 7 },
                    new Lada(){LadaName="745",RegionId = 7 },
                    new Lada(){LadaName="746",RegionId = 7 },
                    new Lada(){LadaName="747",RegionId = 7 },
                    new Lada(){LadaName="749",RegionId = 7 },
                    new Lada(){LadaName="754",RegionId = 7 },
                    new Lada(){LadaName="755",RegionId = 7 },
                    new Lada(){LadaName="756",RegionId = 7 },
                    new Lada(){LadaName="757",RegionId = 7 },
                    new Lada(){LadaName="758",RegionId = 7 },
                    new Lada(){LadaName="762",RegionId = 7 },
                    new Lada(){LadaName="764",RegionId = 7 },
                    new Lada(){LadaName="765",RegionId = 7 },
                    new Lada(){LadaName="766",RegionId = 7 },
                    new Lada(){LadaName="767",RegionId = 7 },
                    new Lada(){LadaName="768",RegionId = 7 },
                    new Lada(){LadaName="776",RegionId = 7 },
                    new Lada(){LadaName="781",RegionId = 7 },
                    new Lada(){LadaName="782",RegionId = 7 },
                    new Lada(){LadaName="783",RegionId = 7 },
                    new Lada(){LadaName="784",RegionId = 7 },
                    new Lada(){LadaName="785",RegionId = 7 },
                    new Lada(){LadaName="789",RegionId = 7 },
                    new Lada(){LadaName="797",RegionId = 7 },
                    new Lada(){LadaName="921",RegionId = 7 },
                    new Lada(){LadaName="922",RegionId = 7 },
                    new Lada(){LadaName="923",RegionId = 7 },
                    new Lada(){LadaName="924",RegionId = 7 },
                    new Lada(){LadaName="951",RegionId = 7 },
                    new Lada(){LadaName="953",RegionId = 7 },
                    new Lada(){LadaName="954",RegionId = 7 },
                    new Lada(){LadaName="958",RegionId = 7 },
                    new Lada(){LadaName="971",RegionId = 7 },
                    new Lada(){LadaName="972",RegionId = 7 },
                    new Lada(){LadaName="995",RegionId = 7 },


                    new Lada(){LadaName="7482",RegionId = 7 },
                    new Lada(){LadaName="7483",RegionId = 7 },
                    new Lada(){LadaName="7484",RegionId = 7 },
                    new Lada(){LadaName="7485",RegionId = 7 },
                    new Lada(){LadaName="7486",RegionId = 7 },
                    new Lada(){LadaName="7487",RegionId = 7 },
                    new Lada(){LadaName="7488",RegionId = 7 },
                    new Lada(){LadaName="7489",RegionId = 7 },

                    new Lada(){LadaName="74811",RegionId = 7 },
                    new Lada(){LadaName="74812",RegionId = 7 },
                    new Lada(){LadaName="74813",RegionId = 7 },
                    new Lada(){LadaName="74814",RegionId = 7 },
                    new Lada(){LadaName="74815",RegionId = 7 },
                    new Lada(){LadaName="74816",RegionId = 7 },
                    new Lada(){LadaName="74817",RegionId = 7 },
                    new Lada(){LadaName="74818",RegionId = 7 },
                    new Lada(){LadaName="74819",RegionId = 7 },

                    new Lada(){LadaName="748106",RegionId = 7 },
                    new Lada(){LadaName="748107",RegionId = 7 },
                    new Lada(){LadaName="748108",RegionId = 7 },
                    new Lada(){LadaName="748109",RegionId = 7 },
                    new Lada(){LadaName="994101",RegionId = 7 },
                    new Lada(){LadaName="994102",RegionId = 7 },
                    new Lada(){LadaName="994103",RegionId = 7 },
                    new Lada(){LadaName="994104",RegionId = 7 },
                    new Lada(){LadaName="994105",RegionId = 7 },

                    new Lada(){LadaName="7481000",RegionId = 7 },
                    new Lada(){LadaName="7481001",RegionId = 7 },
                    new Lada(){LadaName="7481002",RegionId = 7 },
                    new Lada(){LadaName="7481003",RegionId = 7 },
                    new Lada(){LadaName="7481004",RegionId = 7 },
                    new Lada(){LadaName="7481005",RegionId = 7 },
                    new Lada(){LadaName="7481006",RegionId = 7 },
                    new Lada(){LadaName="7481007",RegionId = 7 },
                    new Lada(){LadaName="7481008",RegionId = 7 },
                    new Lada(){LadaName="7481051",RegionId = 7 },
                    new Lada(){LadaName="7481052",RegionId = 7 },
                    new Lada(){LadaName="7481053",RegionId = 7 },
                    new Lada(){LadaName="7481054",RegionId = 7 },
                    new Lada(){LadaName="7481055",RegionId = 7 },
                    new Lada(){LadaName="7481056",RegionId = 7 },
                    new Lada(){LadaName="7481057",RegionId = 7 },
                    new Lada(){LadaName="7481058",RegionId = 7 },
                    new Lada(){LadaName="7481059",RegionId = 7 },
                    new Lada(){LadaName="9942633",RegionId = 7 },
                    new Lada(){LadaName="9942634",RegionId = 7 },
                    new Lada(){LadaName="9942635",RegionId = 7 },
                    new Lada(){LadaName="9942636",RegionId = 7 },
                    new Lada(){LadaName="9942637",RegionId = 7 },
                    new Lada(){LadaName="9942638",RegionId = 7 },
                    new Lada(){LadaName="9942639",RegionId = 7 },


                    new Lada(){LadaName="914",RegionId = 8 },
                    new Lada(){LadaName="916",RegionId = 8 },
                    new Lada(){LadaName="917",RegionId = 8 },
                    new Lada(){LadaName="918",RegionId = 8 },
                    new Lada(){LadaName="919",RegionId = 8 },
                    new Lada(){LadaName="932",RegionId = 8 },
                    new Lada(){LadaName="933",RegionId = 8 },
                    new Lada(){LadaName="934",RegionId = 8 },
                    new Lada(){LadaName="936",RegionId = 8 },
                    new Lada(){LadaName="937",RegionId = 8 },
                    new Lada(){LadaName="938",RegionId = 8 },
                    new Lada(){LadaName="961",RegionId = 8 },
                    new Lada(){LadaName="962",RegionId = 8 },
                    new Lada(){LadaName="963",RegionId = 8 },
                    new Lada(){LadaName="964",RegionId = 8 },
                    new Lada(){LadaName="965",RegionId = 8 },
                    new Lada(){LadaName="966",RegionId = 8 },
                    new Lada(){LadaName="967",RegionId = 8 },
                    new Lada(){LadaName="968",RegionId = 8 },
                    new Lada(){LadaName="969",RegionId = 8 },
                    new Lada(){LadaName="981",RegionId = 8 },
                    new Lada(){LadaName="982",RegionId = 8 },
                    new Lada(){LadaName="983",RegionId = 8 },
                    new Lada(){LadaName="984",RegionId = 8 },
                    new Lada(){LadaName="985",RegionId = 8 },
                    new Lada(){LadaName="986",RegionId = 8 },
                    new Lada(){LadaName="987",RegionId = 8 },
                    new Lada(){LadaName="988",RegionId = 8 },
                    new Lada(){LadaName="991",RegionId = 8 },
                    new Lada(){LadaName="992",RegionId = 8 },
                    new Lada(){LadaName="993",RegionId = 8 },
                    new Lada(){LadaName="996",RegionId = 8 },
                    new Lada(){LadaName="997",RegionId = 8 },
                    new Lada(){LadaName="998",RegionId = 8 },
                    new Lada(){LadaName="999",RegionId = 8 },

                    new Lada(){LadaName="994100",RegionId = 8 },
                    new Lada(){LadaName="9942630",RegionId = 8 },
                    new Lada(){LadaName="9942631",RegionId = 8 },
                    new Lada(){LadaName="9942632",RegionId = 8 },

                    new Lada(){LadaName="55",RegionId = 9 },

                    new Lada(){LadaName="588",RegionId = 9 },
                    new Lada(){LadaName="591",RegionId = 9 },
                    new Lada(){LadaName="592",RegionId = 9 },
                    new Lada(){LadaName="593",RegionId = 9 },
                    new Lada(){LadaName="594",RegionId = 9 },
                    new Lada(){LadaName="595",RegionId = 9 },
                    new Lada(){LadaName="596",RegionId = 9 },
                    new Lada(){LadaName="597",RegionId = 9 },
                    new Lada(){LadaName="599",RegionId = 9 },
                    new Lada(){LadaName="711",RegionId = 9 },
                    new Lada(){LadaName="712",RegionId = 9 },
                    new Lada(){LadaName="713",RegionId = 9 },
                    new Lada(){LadaName="714",RegionId = 9 },
                    new Lada(){LadaName="716",RegionId = 9 },
                    new Lada(){LadaName="717",RegionId = 9 },
                    new Lada(){LadaName="718",RegionId = 9 },
                    new Lada(){LadaName="719",RegionId = 9 },
                    new Lada(){LadaName="721",RegionId = 9 },
                    new Lada(){LadaName="722",RegionId = 9 },
                    new Lada(){LadaName="723",RegionId = 9 },
                    new Lada(){LadaName="724",RegionId = 9 },
                    new Lada(){LadaName="725",RegionId = 9 },
                    new Lada(){LadaName="726",RegionId = 9 },
                    new Lada(){LadaName="728",RegionId = 9 },
                    new Lada(){LadaName="731",RegionId = 9 },
                    new Lada(){LadaName="734",RegionId = 9 },
                    new Lada(){LadaName="735",RegionId = 9 },
                    new Lada(){LadaName="737",RegionId = 9 },
                    new Lada(){LadaName="738",RegionId = 9 },
                    new Lada(){LadaName="743",RegionId = 9 },
                    new Lada(){LadaName="751",RegionId = 9 },
                    new Lada(){LadaName="759",RegionId = 9 },
                    new Lada(){LadaName="761",RegionId = 9 },
                    new Lada(){LadaName="763",RegionId = 9 },
                    new Lada(){LadaName="769",RegionId = 9 },
                    new Lada(){LadaName="771",RegionId = 9 },
                    new Lada(){LadaName="772",RegionId = 9 },
                    new Lada(){LadaName="773",RegionId = 9 },
                    new Lada(){LadaName="774",RegionId = 9 },
                    new Lada(){LadaName="775",RegionId = 9 },
                    new Lada(){LadaName="777",RegionId = 9 },
                    new Lada(){LadaName="778",RegionId = 9 },
                    new Lada(){LadaName="779",RegionId = 9 },
                    new Lada(){LadaName="791",RegionId = 9 },

                    new Lada(){LadaName="748101",RegionId = 9 },
                    new Lada(){LadaName="748102",RegionId = 9 },
                    new Lada(){LadaName="748103",RegionId = 9 },
                    new Lada(){LadaName="748104",RegionId = 9 },

                    new Lada(){LadaName="7481009",RegionId = 9 },
                    new Lada(){LadaName="7481050",RegionId = 9 },

                };
            }
        }
    }
}
