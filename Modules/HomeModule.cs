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
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml"];
      };
      Get["/contact/add"] = _ => {
        return View["add_contact.cshtml"];
      };
      Post["/contact/new"] = _ => {
        Contact newContact = new Contact(Request.Form["add-contact"], Request.Form["add-phoneNumber"], Request.Form["add-address"]);
        return View["new_contact_confirmation.cshtml"];
      };
      Get["/contact/new"] = _ =>{
        return View["new_contact_confirmation.cshtml"];
      };
      Get["/contacts/{id}"] = parameters => {
        Contact newContact = Contact.Find(parameters.id);
        return View["contact_info.cshtml", newContact];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["cleared.cshtml"];
      };
    }
  }
}
