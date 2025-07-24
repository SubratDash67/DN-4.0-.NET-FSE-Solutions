import '../stylesheets/mystyle.css';

const percentToDecimal = (decimal) => {
  return `${(decimal * 100).toFixed(2)}%`;
};

const calcScore = (total, goal) => {
  return percentToDecimal(total / goal);
};

export const CalculateScore = ({ Name, School, total, goal }) => {
  return (
    <div className="formatstyle">
      <h1>
        <font>Name and School Info</font>
      </h1>
      <div>
        <b>Name:</b> <span className="Name">{Name}</span>
      </div>
      <div>
        <b>School:</b> <span className="School">{School}</span>
      </div>
      <div>
        <b>Score:</b> <span className="Score">{calcScore(total, goal)}</span>
      </div>
    </div>
  );
};
export default CalculateScore;