import { CalculateScore } from '../src/components/CalculateScore';

function App() {
  return (
    <CalculateScore
      Name={"John Doe"}
      School={"DNV Public School"}
      total={284}
      goal={300}
    />
  );
}

export default App;
