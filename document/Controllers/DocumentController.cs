using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace document.Controllers;

[Authorize] // Requires ANY authenticated user
[ApiController]
[Route("[controller]")]
public class DocumentsController : ControllerBase
{
    static readonly string[] scopeRequiredByApi = new string[] { "Documents.ReadWrite" };

    [HttpGet]
    public IActionResult Get()
    {
        HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

        return Ok(new string[] { "Q3 Financial Report.pdf", "Project Phoenix Plan.docx" });
    }
}