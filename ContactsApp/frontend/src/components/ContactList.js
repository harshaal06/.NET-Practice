import React, { useState, useEffect } from 'react';
import { contactService } from '../services/api';
import './ContactList.css';

const ContactList = ({ refreshTrigger }) => {
  const [contacts, setContacts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  const fetchContacts = async () => {
    setLoading(true);
    setError('');
    try {
      const data = await contactService.getAllContacts();
      setContacts(data);
    } catch (err) {
      setError('Failed to fetch contacts');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchContacts();
  }, [refreshTrigger]);

  if (loading) {
    return <div className="contact-list-container">Loading contacts...</div>;
  }

  if (error) {
    return <div className="contact-list-container error-message">{error}</div>;
  }

  return (
    <div className="contact-list-container">
      <h2>Contacts List</h2>
      {contacts.length === 0 ? (
        <p className="no-contacts">No contacts found. Add your first contact above!</p>
      ) : (
        <table className="contacts-table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Phone Number</th>
            </tr>
          </thead>
          <tbody>
            {contacts.map((contact) => (
              <tr key={contact.id}>
                <td>{contact.id}</td>
                <td>{contact.name}</td>
                <td>{contact.phoneNumber}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default ContactList;
