import FlightDetails from './FlightDetails';

function GuestPage() {
  return (
    <div>
      <h1>Guest User - Browse Flights</h1>
      <p>You can browse flight details below. Please log in to book tickets.</p>
      <FlightDetails />
    </div>
  );
}

export default GuestPage;
