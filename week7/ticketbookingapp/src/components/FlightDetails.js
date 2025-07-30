function FlightDetails() {
  const flights = [
    { id: 1, from: 'New York', to: 'London', price: '$650', time: '08:00 AM' },
    { id: 2, from: 'London', to: 'Paris', price: '$280', time: '02:30 PM' },
    { id: 3, from: 'Tokyo', to: 'Seoul', price: '$320', time: '11:15 AM' },
    { id: 4, from: 'Mumbai', to: 'Dubai', price: '$380', time: '06:45 PM' }
  ];

  return (
    <div style={{ padding: '20px' }}>
      <h2>Available Flights</h2>
      <div style={{ display: 'grid', gap: '15px', marginTop: '20px' }}>
        {flights.map(flight => (
          <div key={flight.id} style={{ 
            border: '1px solid #ccc', 
            padding: '15px', 
            borderRadius: '5px',
            backgroundColor: '#f9f9f9'
          }}>
            <h3>{flight.from} → {flight.to}</h3>
            <p>Departure: {flight.time}</p>
            <p>Price: {flight.price}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default FlightDetails;
