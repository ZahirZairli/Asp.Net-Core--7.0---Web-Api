using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApi.DAL.Context;
using TraversalApi.DAL.Entities;

namespace TraversalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public ActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor newVisitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(newVisitor);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetVisitorById(int id)
        {
            using (var context = new VisitorContext())
            {
                var visitor = context.Visitors.Find(id);
                if (visitor == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(visitor);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var context = new VisitorContext())
            {
                var visitor = context.Visitors.Find(id);
                if (visitor == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(visitor);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor upvisitor)
        {
            using (var context = new VisitorContext())
            {
                var visitor = context.Visitors.Find(upvisitor.VisitorId);
                if (visitor == null)
                {
                    return NotFound();
                }
                else
                {
                    visitor.Name = upvisitor.Name;
                    visitor.Surname = upvisitor.Surname;
                    visitor.City = upvisitor.City;
                    visitor.Country = upvisitor.Country;
                    context.Update(visitor);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
