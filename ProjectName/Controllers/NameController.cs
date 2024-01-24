using Microsoft.AspNetCore.Mvc;
using ExampleName.Models;

namespace ExampleName.Controllers
{
  public class ExampleNameController : Controller
  {
    [Route("/")]
    public string Example() { return "Hello Friend!"; }
  }
}