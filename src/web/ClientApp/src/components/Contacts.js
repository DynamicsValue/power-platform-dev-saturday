import React, { Component } from 'react';

export class Contacts extends Component {
  static displayName = Contacts.name;

  constructor(props) {
    super(props);
    this.state = { contacts: [], loading: true };
  }

  componentDidMount() {
    this.populateContactData();
  }

  static renderContactsTable(contacts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Full Name</th>
            <th>Email</th>
            <th>Company Name</th>
            <th>Business Phone</th>
          </tr>
        </thead>
        <tbody>
          {contacts.map(contact =>
            <tr key={contact.id}>
              <td>{contact.fullName}</td>
              <td>{contact.email}</td>
              <td>{contact.companyName}</td>
              <td>{contact.businessPhone}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Contacts.renderContactsTable(this.state.contacts);

    return (
      <div>
        <h1 id="tabelLabel" >All Contacts</h1>
        <p>This component demonstrates fetching contact data from CDS.</p>
        {contents}
      </div>
    );
  }

  async populateContactData() {
    const response = await fetch('api/contacts');
    const data = await response.json();
    this.setState({ contacts: data, loading: false });
  }
}
