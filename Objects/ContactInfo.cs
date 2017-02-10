
using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook.Objects
{
  public class ContactInfo
  {
    private static List<ContactInfo> _instances = new List<Contact> {};
    private string _contactName;
    private string _contactPhoneNumber;
    private string _contactAddress;
    private int _id;
    private List<Contact> _contactInfo;

    public ContactInfo(string contactName)
    {
      _contactName = contactName;
      _contactPhoneNumber = contactPhoneNumber;
      _contactAddress = contactAddress;
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
    public List<ContactInfo> GetContactInfo()
    {
      return _contactInfo;
    }
    public void AddContact(ContactInfo contactinfo)
    {
      _contactInfo.Add(contactInfo);
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
