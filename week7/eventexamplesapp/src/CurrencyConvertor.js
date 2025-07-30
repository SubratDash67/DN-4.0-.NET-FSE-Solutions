import React, { useState } from 'react';

const CurrencyConvertor = () => {
  const [amount, setAmount] = useState('');
  const [currency, setCurrency] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (amount && !isNaN(amount)) {
      const euroAmount = (parseFloat(amount) / 83).toFixed(2);
      setCurrency(`Euro: ${euroAmount}`);
      alert(`Converting Rs. ${amount} to ${euroAmount} Euro`);
    } else {
      alert('Please enter a valid amount');
    }
  };

  return (
    <div style={{ marginTop: '30px' }}>
      <h2 style={{ color: 'green' }}>Currency Convertor!!!</h2>
      <form onSubmit={handleSubmit}>
        <div style={{ margin: '10px 0' }}>
          <label>Amount: </label>
          <input
            type="text"
            value={amount}
            onChange={(e) => setAmount(e.target.value)}
            style={{ marginLeft: '10px', padding: '5px' }}
          />
        </div>
        <div style={{ margin: '10px 0' }}>
          <label>Currency: </label>
          <input
            type="text"
            value={currency}
            readOnly
            style={{ marginLeft: '10px', padding: '5px' }}
          />
        </div>
        <button type="submit" style={{ marginTop: '10px', padding: '5px 15px' }}>
          Submit
        </button>
      </form>
    </div>
  );
};

export default CurrencyConvertor;
