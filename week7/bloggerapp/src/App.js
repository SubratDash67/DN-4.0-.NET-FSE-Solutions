import React, { useState } from 'react';
import './App.css';
import BookDetails from './components/BookDetails';
import BlogDetails from './components/BlogDetails';
import CourseDetails from './components/CourseDetails';
import ConditionalRenderer from './components/ConditionalRenderer';

function App() {
  const [showBooks, setShowBooks] = useState(true);
  const [showBlogs, setShowBlogs] = useState(true);
  const [showCourses, setShowCourses] = useState(true);
  const [renderMethod, setRenderMethod] = useState('all');

  const handleToggleBooks = () => setShowBooks(!showBooks);
  const handleToggleBlogs = () => setShowBlogs(!showBlogs);
  const handleToggleCourses = () => setShowCourses(!showCourses);

  const renderConditionalComponents = () => {
    switch (renderMethod) {
      case 'books':
        return <BookDetails />;
      case 'blogs':
        return <BlogDetails />;
      case 'courses':
        return <CourseDetails />;
      case 'all':
      default:
        return (
          <>
            {showCourses && <CourseDetails />}
            {showBooks && <BookDetails />}
            {showBlogs && <BlogDetails />}
          </>
        );
    }
  };

  let componentToRender;
  if (renderMethod === 'books') {
    componentToRender = <BookDetails />;
  } else if (renderMethod === 'blogs') {
    componentToRender = <BlogDetails />;
  } else if (renderMethod === 'courses') {
    componentToRender = <CourseDetails />;
  } else {
    componentToRender = (
      <>
        {showCourses && <CourseDetails />}
        {showBooks && <BookDetails />}
        {showBlogs && <BlogDetails />}
      </>
    );
  }

  return (
    <div className="App">
      <header className="app-header">
        <h1>Blogger App - Conditional Rendering Demo</h1>
        
        <div className="controls">
          <h3>Toggle Components:</h3>
          <button onClick={handleToggleBooks}>
            {showBooks ? 'Hide Books' : 'Show Books'}
          </button>
          <button onClick={handleToggleBlogs}>
            {showBlogs ? 'Hide Blogs' : 'Show Blogs'}
          </button>
          <button onClick={handleToggleCourses}>
            {showCourses ? 'Hide Courses' : 'Show Courses'}
          </button>
          
          <h3>Render Method:</h3>
          <select 
            value={renderMethod} 
            onChange={(e) => setRenderMethod(e.target.value)}
          >
            <option value="all">Show All</option>
            <option value="books">Books Only</option>
            <option value="blogs">Blogs Only</option>
            <option value="courses">Courses Only</option>
          </select>
        </div>
      </header>

      <main className="app-content">
        <h2>Method 1: Logical AND (&&) Operator</h2>
        <div className="method-demo">
          {showCourses && <CourseDetails />}
          {showBooks && <BookDetails />}
          {showBlogs && <BlogDetails />}
        </div>

        <h2>Method 2: Ternary Operator</h2>
        <div className="method-demo">
          {renderMethod === 'books' ? (
            <BookDetails />
          ) : renderMethod === 'blogs' ? (
            <BlogDetails />
          ) : renderMethod === 'courses' ? (
            <CourseDetails />
          ) : (
            <div className="all-components">
              {showCourses && <CourseDetails />}
              {showBooks && <BookDetails />}
              {showBlogs && <BlogDetails />}
            </div>
          )}
        </div>

        <h2>Method 3: Switch Statement</h2>
        <div className="method-demo">
          {renderConditionalComponents()}
        </div>

        <h2>Method 4: Element Variables</h2>
        <div className="method-demo">
          {componentToRender}
        </div>

        <h2>Method 5: Function-based Conditional Rendering</h2>
        <div className="method-demo">
          {(() => {
            if (!showBooks && !showBlogs && !showCourses) {
              return <div><h3>No components to display</h3></div>;
            }
            return (
              <>
                {showCourses ? <CourseDetails /> : null}
                {showBooks ? <BookDetails /> : null}
                {showBlogs ? <BlogDetails /> : null}
              </>
            );
          })()}
        </div>

        <h2>Method 6: Multiple Conditional Returns</h2>
        <div className="method-demo">
          {renderMethod === 'none' && (
            <div><h3>Nothing to show</h3></div>
          )}
          {renderMethod !== 'none' && (
            <>
              {(renderMethod === 'all' || renderMethod === 'courses') && showCourses && <CourseDetails />}
              {(renderMethod === 'all' || renderMethod === 'books') && showBooks && <BookDetails />}
              {(renderMethod === 'all' || renderMethod === 'blogs') && showBlogs && <BlogDetails />}
            </>
          )}
        </div>

        <h2>Method 7: Interactive Tab-based Conditional Rendering</h2>
        <ConditionalRenderer />
      </main>
    </div>
  );
}

export default App;
