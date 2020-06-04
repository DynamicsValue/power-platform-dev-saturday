import React, { Component } from 'react';


export class ContactDetails extends Component {
  static displayName = ContactDetails.name;

  constructor(props) {
    super(props);

    this.firstNameChanged = this.firstNameChanged.bind(this);
    this.lastNameChanged = this.lastNameChanged.bind(this);
    this.emailChanged = this.emailChanged.bind(this);
    this.phoneChanged = this.phoneChanged.bind(this);

    this.state = { model: {}, loading: true, isSaving: false, errorMessage: '' };
  }

  componentDidMount() {
    var id = this.props.match.params.id;
    if(id) 
    {
      this.getContactDetails(id);
    }
    else {
      var contact = this.newContact();
      this.setState({ model: contact, loading: false });
    }
  }

  firstNameChanged = (event) => 
  {
    const updatedFirstName = event.target.value;
    var model = this.state.model;
    model.firstName = updatedFirstName;
    this.setState({model: model});
  }

  lastNameChanged = (event) => 
  {
    const updatedLastName = event.target.value;
    var model = this.state.model;
    model.lastName = updatedLastName;
    this.setState({model: model});
  }

  emailChanged = (event) => 
  {
    const updatedEmail = event.target.value;
    var model = this.state.model;
    model.email = updatedEmail;
    this.setState({model: model});
  }

  phoneChanged = (event) => 
  {
    const updatedPhone = event.target.value;
    var model = this.state.model;
    model.businessPhone = updatedPhone;
    this.setState({model: model});
  }

  async save(event) {
    event.preventDefault();

    var id = this.props.match.params.id;
    var result = null
    if(id) {
      result = await this.updateContactDetails(id);
    }
    else {
      result = await this.createContact();
    }

    this.setState({ isSaving: false, errorMessage: result.errorMessage });

  }

  renderContactForm(contact) {
    let errorMessage = this.state.errorMessage !== '' ? 
    (<div class="alert alert-danger" role="alert">
        There was an error when saving this record: {this.state.errorMessage}
    </div>) : <div></div>;

    return (<form>
        {errorMessage}
        <div className="form-group">
          <label htmlFor="exampleFirstName">First Name</label>
          <input type="text" className="form-control" id="exampleFirstName" aria-describedby="firstHelp" placeholder="Enter first name" onChange={(event) => this.firstNameChanged(event)} value={contact.firstName}  />
          <small id="firstHelp" className="form-text text-muted">Your first name here.</small>
        </div>
        <div className="form-group">
          <label htmlFor="exampleLastName">Last Name</label>
          <input type="text" className="form-control" id="exampleLastName" aria-describedby="firstHelp" placeholder="Enter last name" onChange={(event) => this.lastNameChanged(event)} value={contact.lastName}  />
          <small id="lastNameHelp" className="form-text text-muted">Your last name here.</small>
        </div>
        <div className="form-group">
          <label htmlFor="exampleInputEmail1">Email address</label>
          <input type="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" onChange={(event) => this.emailChanged(event)} value={contact.email} />
          <small id="emailHelp" className="form-text text-muted">We'll never share your email with anyone else. Email must be unique.</small>
        </div>
        <div className="form-group">
          <label htmlFor="examplePhone">Phone</label>
          <input type="text" className="form-control" id="examplePhone" aria-describedby="phoneHelp" placeholder="Enter your business phone number" onChange={(event) => this.phoneChanged(event)} value={contact.businessPhone}  />
          <small id="phoneHelp" className="form-text text-muted">Your phone number here.</small>
        </div>
        <button className="btn btn-primary" disabled={this.state.isSaving} onClick={(event) => this.save(event)}>{this.state.isSaving ? 'Saving...' : 'Save'}</button>
      </form>);
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderContactForm(this.state.model);

    return (
      <div>
        <h1 id="tabelLabel" >Contact Details</h1>
        <p>This component demonstrates CRUD operations from/to CDS.</p>
        {contents}
      </div>
    );
  }

  async getContactDetails(id) {
    const response = await fetch(`api/contacts/${id}`);
    const data = await response.json();
    this.setState({ model: data, loading: false });
  }

  async updateContactDetails(id) {
    this.setState({ isSaving: true, errorMessage: '' });
    const response = await fetch(`api/contacts/${id}`, 
    {
      method: 'POST', 
      body: JSON.stringify(this.state.model),
      headers:{
        'Content-Type': 'application/json'
      }
    });
    return await response.json();
  }

  async createContact() {
    this.setState({ isSaving: true, errorMessage: '' });
    const response = await fetch(`api/contacts`, 
    {
      method: 'PUT', 
      body: JSON.stringify(this.state.model),
      headers:{
        'Content-Type': 'application/json'
      }
    });
    return await response.json();
  }

  newContact() {
    return {
      firstName: "",
      lastName: "",
      email: "",
      businessPhone: ""
    };
  }
  
}
