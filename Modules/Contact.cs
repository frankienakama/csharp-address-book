
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
    private List<ContactInfo> _contactInfo;

    public Contact(string ContactName)
    {
      _contactName = ContactName;
      _instances.Add(this);
      _id = _instances.Count;
      _contactInfo = new List<ContactInfo>{};
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
    public List<ContactInfo> GetAddressBookEntries()
    {
      return _contactInfo
    }
    public void AddAddressBookEntry(ContactInfo contact)
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
