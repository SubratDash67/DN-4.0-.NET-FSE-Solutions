import React from 'react';

const ListofPlayers = () => {
  const players = [
    { name: 'Jack', score: 50 },
    { name: 'Michael', score: 70 },
    { name: 'John', score: 40 },
    { name: 'Ann', score: 61 },
    { name: 'Elizabeth', score: 61 },
    { name: 'Sachin', score: 95 },
    { name: 'Dhoni', score: 100 },
    { name: 'Virat', score: 84 },
    { name: 'Jadeja', score: 64 },
    { name: 'Raina', score: 75 },
    { name: 'Rohit', score: 80 }
  ];

  const players70 = [];

  const filterPlayers = () => {
    return players.filter((item) => {
      return item.score <= 70;
    });
  };

  filterPlayers();

  return (
    <div>
      <h2>List of Players</h2>
      {players.map((item) => (
        <li key={item.name}>Mr. {item.name} {item.score}</li>
      ))}
      
      <h2>List of Players having Scores Less than 70</h2>
      {players70.map((item) => (
        <li key={item.name}>Mr. {item.name} {item.score}</li>
      ))}
    </div>
  );
};

export default ListofPlayers;
