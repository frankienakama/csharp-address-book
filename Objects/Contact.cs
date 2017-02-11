using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;
    private List<Contact> _contact;

    public Contact(string contactName)
    {
      _name = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _contact = new List<Contact>{};
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Contact> GetContacts()
    {
      return _contact;
    }
    public void AddContact(Contact contact)
    {
      _contact.Add(contact);
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
