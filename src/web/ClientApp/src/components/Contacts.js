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
      <div>
        <a className="btn btn-primary" href={`/contact-details`}>Add New..</a>
        <br /><br />
        <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Full Name</th>
            <th>Email</th>
            <th>Company Name</th>
            <th>Business Phone</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {contacts.map(contact =>
            <tr key={contact.id}>
              <td>{contact.fullName}</td>
              <td>{contact.email}</td>
              <td>{contact.companyName}</td>
              <td>{contact.businessPhone}</td>
              <td><a className="btn btn-primary" href={`/contact-details/${contact.id}`}>View / Edit</a></td>
            </tr>
          )}
        </tbody>
      </table>
      <br /><br />
      <a className="btn btn-primary" href={`/contact-details`}>Add New..</a>
      </div>
      
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
