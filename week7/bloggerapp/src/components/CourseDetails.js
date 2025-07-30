import { courses } from '../data/data';

function CourseDetails() {
  const coursedet = courses.map((course) => (
    <div key={course.id}>
      <h2>{course.name}</h2>
      <p>{course.date}</p>
    </div>
  ));

  return (
    <div>
      <div>
        <div className="mystyle1">
          <h1>Course Details</h1>
          {coursedet}
        </div>
      </div>
    </div>
  );
}

export default CourseDetails;
