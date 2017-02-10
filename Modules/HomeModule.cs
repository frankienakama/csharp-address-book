using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Post["/contact/add"] = _ => {
        Contact newContact = new Contact(Request.Form["add-contact"]), Request.Form["add-phoneNumber"], Request.Form["add-address"]);
        return View["add_contact.cshtml"];
      };
      Get["/new-contact"] = _ =>{
        return View["new_contact_confirmation.cshtml"];
      }
      Get["/contacts/{id}"] = parameters => {
        Contact newContact = Contact.Find(parameters.id);
        return View["contact_info.cshtml", contact];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["cleared.cshtml"];
      };
    }
  }
}
