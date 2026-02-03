import React, { useState } from 'react';
import ContactForm from './components/ContactForm';
import ContactList from './components/ContactList';
import './App.css';

function App() {
  const [refreshTrigger, setRefreshTrigger] = useState(0);

  const handleContactAdded = () => {
    setRefreshTrigger(prev => prev + 1);
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Contacts Application</h1>
      </header>
      <main>
        <ContactForm onContactAdded={handleContactAdded} />
        <ContactList refreshTrigger={refreshTrigger} />
      </main>
    </div>
  );
}

export default App;
