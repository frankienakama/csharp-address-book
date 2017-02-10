
using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook.Objects
{
  public class ContactInfo
  {
    private static List<ContactInfo> _instances = new List<ContactInfo> {};
    private string _contactName;
    private string _contactPhoneNumber;
    private string _contactAddress;
    private int _id;
    private List<ContactInfo> _contactInfo;

    public ContactInfo(string contactName, string contactPhoneNumber, string contactAddress)
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
    public void AddContact(ContactInfo contactInfo)
    {
      _contactInfo.Add(contactInfo);
    }
    public static List<ContactInfo> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static ContactInfo Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
