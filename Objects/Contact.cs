
using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _contactName;
    private string _contactPhoneNumber;
    private string _contactAddress;
    private int _id;
    private List<Contact> _contactInfo;

    public Contact(string contactName)
    {
      _contactName = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _contactInfo = new List<Contact>{};
    }

    public string GetContactName()
    {
      return _contactName;
    }
    public string GetContactPhoneNumber()
    {
      return _contactPhoneNumber;
    }
    public string GetContactAddress()
    {
      return _contactAddress;
    }
    public List<Contact> GetAddressBookEntries()
    {
      return _contactInfo;
    }
    public void AddAddressBookEntry(Contact contact)
    {
      _contactInfo.Add(contact);
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
