import { useState } from 'react';

function BookingForm() {
  const [selectedFlight, setSelectedFlight] = useState('');
  const [passengerName, setPassengerName] = useState('');
  const [email, setEmail] = useState('');

  const flights = [
    { id: 1, from: 'New York', to: 'London', price: '$650', time: '08:00 AM' },
    { id: 2, from: 'London', to: 'Paris', price: '$280', time: '02:30 PM' },
    { id: 3, from: 'Tokyo', to: 'Seoul', price: '$320', time: '11:15 AM' },
    { id: 4, from: 'Mumbai', to: 'Dubai', price: '$380', time: '06:45 PM' }
  ];

  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Booking confirmed for ${passengerName} on ${selectedFlight}`);
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Book Your Flight</h2>
      <form onSubmit={handleSubmit} style={{ maxWidth: '400px', marginTop: '20px' }}>
        <div style={{ marginBottom: '15px' }}>
          <label>Select Flight:</label>
          <select 
            value={selectedFlight} 
            onChange={(e) => setSelectedFlight(e.target.value)}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required
          >
            <option value="">Choose a flight</option>
            {flights.map(flight => (
              <option key={flight.id} value={`${flight.from} to ${flight.to}`}>
                {flight.from} → {flight.to} - {flight.price} ({flight.time})
              </option>
            ))}
          </select>
        </div>
        
        <div style={{ marginBottom: '15px' }}>
          <label>Passenger Name:</label>
          <input
            type="text"
            value={passengerName}
            onChange={(e) => setPassengerName(e.target.value)}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required
          />
        </div>
        
        <div style={{ marginBottom: '15px' }}>
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required
          />
        </div>
        
        <button 
          type="submit"
          style={{ 
            backgroundColor: '#007bff', 
            color: 'white', 
            padding: '10px 20px', 
            border: 'none', 
            borderRadius: '5px',
            cursor: 'pointer'
          }}
        >
          Book Ticket
        </button>
      </form>
    </div>
  );
}

export default BookingForm;
