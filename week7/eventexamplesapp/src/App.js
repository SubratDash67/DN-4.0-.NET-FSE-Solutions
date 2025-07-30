import React, { useState } from 'react';
import './App.css';
import CurrencyConvertor from './CurrencyConvertor';

function App() {
  const [counter, setCounter] = useState(5);

  const increment = () => {
    setCounter(counter + 1);
  };

  const decrement = () => {
    setCounter(counter - 1);
  };

  const sayHello = () => {
    alert('Hello Member!');
  };

  const handleIncrement = () => {
    increment();
    sayHello();
  };

  const sayWelcome = (message) => {
    alert(message);
  };

  const onPress = (e) => {
    alert('I was clicked');
  };

  return (
    <div className="App">
      <div style={{ padding: '20px' }}>
        <h2>{counter}</h2>
        
        <div style={{ margin: '20px 0' }}>
          <button onClick={handleIncrement} style={{ margin: '5px', padding: '5px 15px' }}>
            Increment
          </button>
          <button onClick={decrement} style={{ margin: '5px', padding: '5px 15px' }}>
            Decrement
          </button>
        </div>

        <div style={{ margin: '20px 0' }}>
          <button 
            onClick={() => sayWelcome('welcome')} 
            style={{ margin: '5px', padding: '5px 15px' }}
          >
            Say welcome
          </button>
        </div>

        <div style={{ margin: '20px 0' }}>
          <button onClick={onPress} style={{ margin: '5px', padding: '5px 15px' }}>
            Click on me
          </button>
        </div>

        <CurrencyConvertor />
      </div>
    </div>
  );
}

export default App;
