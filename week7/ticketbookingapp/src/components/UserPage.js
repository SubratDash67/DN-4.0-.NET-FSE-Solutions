import BookingForm from './BookingForm';

function UserPage() {
  return (
    <div>
      <h1>Welcome User - Book Your Flight</h1>
      <p>You are logged in and can now book flight tickets!</p>
      <BookingForm />
    </div>
  );
}

export default UserPage;
