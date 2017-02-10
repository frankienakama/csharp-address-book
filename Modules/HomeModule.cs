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
      Get["/contacts"] = _ => {
        var allCategories = Category.GetAll();
        return View["contacts.cshtml", allCategories];
      };
      Get["/contacts/new"] = _ => {
        return View["add_contact.cshtml"];
      };
      Post["/contacts"] = _ => {
        var newCategory = new Category(Request.Form["add-contact"]);
        var allCategories = Category.GetAll();
        return View["contacts.cshtml", allCategories];
      };
      Get["/contacts/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedCategory = Category.Find(parameters.id);
        var categoryTasks = selectedCategory.GetTasks();
        model.Add("category", selectedCategory);
        model.Add("tasks", categoryTasks);
        return View["contact.cshtml", model];
      };
      Post["/contact_info"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<Task> categoryTasks = selectedCategory.GetTasks();
        string taskDescription = Request.Form["task-description"];
        Task newTask = new Task(taskDescription);
        categoryTasks.Add(newTask);
        model.Add("tasks", categoryTasks);
        model.Add("category", selectedCategory);
        return View["contact.cshtml", model];
      };
    }
  }
}
