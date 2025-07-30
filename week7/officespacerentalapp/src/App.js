import React from 'react';
import './App.css';

function App() {
  const office = {
    name: 'DBS',
    rent: 50000,
    address: 'Chennai',
    image: '/office-space.jpg'
  };

  const officeSpaces = [
    {
      id: 1,
      name: 'DBS',
      rent: 50000,
      address: 'Chennai',
      image: '/office-space.jpg'
    },
    {
      id: 2,
      name: 'TCS Office',
      rent: 70000,
      address: 'Bangalore',
      image: '/tcs.jpeg'
    },
    {
      id: 3,
      name: 'Infosys Hub',
      rent: 45000,
      address: 'Hyderabad',
      image: '/infosys.jpeg'
    },
    {
      id: 4,
      name: 'Tech Park',
      rent: 80000,
      address: 'Mumbai',  
      image: '/tech park.jpeg'
    }
  ];

  const colors = [];
  
  const getColorStyle = (rent) => {
    if (rent < 60000) {
      colors.push('textRed');
      return { color: 'red' };
    } else {
      colors.push('textGreen');
      return { color: 'green' };
    }
  };

  return (
    <div className="App">
      <h1>Office Space , at Affordable Range</h1>
      
      <div className="office-card">
        <img src={office.image} alt="Office Space" style={{width: '300px', height: '200px'}} />
        <h2>Name: {office.name}</h2>
        <p style={getColorStyle(office.rent)}>Rent: Rs. {office.rent}</p>
        <p>Address: {office.address}</p>
      </div>

      <div className="office-list">
        {officeSpaces.map((item) => (
          <div key={item.id} className="office-item">
            <img src={item.image} alt={item.name} style={{width: '250px', height: '150px'}} />
            <h3>Name: {item.name}</h3>
            <p style={getColorStyle(item.rent)}>Rent: Rs. {item.rent}</p>
            <p>Address: {item.address}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;
