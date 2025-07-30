import React from 'react';

const IndianPlayers = () => {
  const T20Players = ['First Player', 'Second Player', 'Third Player'];
  const RanjiTrophyPlayers = ['Fourth Player', 'Fifth Player', 'Sixth Player'];
  
  const [first, , third, , fifth] = T20Players.concat(RanjiTrophyPlayers);
  const [, second, , fourth, , sixth] = T20Players.concat(RanjiTrophyPlayers);
  
  const IndianTeamPlayers = [...T20Players, ...RanjiTrophyPlayers];

  const OddPlayers = (first, third, fifth) => {
    return (
      <div>
        <li>First : {first}</li>
        <li>Third : {third}</li>
        <li>Fifth : {fifth}</li>
      </div>
    );
  };

  return (
    <div>
      <h2>Odd Players</h2>
      {OddPlayers(first, third, fifth)}
      
      <h2>Even Players</h2>
      <div>
        <li>Second : {second}</li>
        <li>Fourth : {fourth}</li>
        <li>Sixth : {sixth}</li>
      </div>
      
      <h2>List of Indian Players Merged:</h2>
      {IndianTeamPlayers.map((item) => (
        <li key={item}>Mr. {item}</li>
      ))}
    </div>
  );
};

export default IndianPlayers;
