import React, { useState } from 'react';
import { books, courses, blogs } from '../data/data';

function ConditionalRenderer() {
  const [activeTab, setActiveTab] = useState('books');
  const [showEmptyState, setShowEmptyState] = useState(false);

  const renderTabContent = () => {
    switch (activeTab) {
      case 'books':
        return (
          <div className="st2">
            <h1>Book Details</h1>
            <ul>
              {books.map((book) => (
                <div key={book.id}>
                  <h3>{book.bname}</h3>
                  <h4>${book.price}</h4>
                </div>
              ))}
            </ul>
          </div>
        );
      case 'courses':
        return (
          <div className="mystyle1">
            <h1>Course Details</h1>
            {courses.map((course) => (
              <div key={course.id}>
                <h2>{course.name}</h2>
                <p>{course.date}</p>
              </div>
            ))}
          </div>
        );
      case 'blogs':
        return (
          <div className="v1">
            <h1>Blog Details</h1>
            {blogs.map((blog) => (
              <div key={blog.id}>
                <h2>{blog.title}</h2>
                <h4>{blog.author}</h4>
                <p>{blog.content}</p>
              </div>
            ))}
          </div>
        );
      default:
        return <div>Please select a tab</div>;
    }
  };

  const TabButton = ({ tab, label, isActive, onClick }) => (
    <button
      className={`tab-button ${isActive ? 'active' : ''}`}
      onClick={() => onClick(tab)}
    >
      {label}
    </button>
  );

  if (showEmptyState) {
    return (
      <div className="empty-state">
        <h2>No content available</h2>
        <button onClick={() => setShowEmptyState(false)}>
          Show Content
        </button>
      </div>
    );
  }

  return (
    <div className="conditional-renderer">
      <div className="tab-controls">
        <TabButton
          tab="books"
          label="Books"
          isActive={activeTab === 'books'}
          onClick={setActiveTab}
        />
        <TabButton
          tab="courses"
          label="Courses"
          isActive={activeTab === 'courses'}
          onClick={setActiveTab}
        />
        <TabButton
          tab="blogs"
          label="Blogs"
          isActive={activeTab === 'blogs'}
          onClick={setActiveTab}
        />
        <button
          className="toggle-empty"
          onClick={() => setShowEmptyState(true)}
        >
          Show Empty State
        </button>
      </div>

      <div className="tab-content">
        {renderTabContent()}
      </div>

      <div className="conditional-examples">
        <h3>Conditional Rendering Examples:</h3>
        
        <h4>1. Ternary Operator:</h4>
        {activeTab === 'books' ? (
          <p>Currently showing books</p>
        ) : (
          <p>Not showing books</p>
        )}

        <h4>2. Logical AND (&&):</h4>
        {activeTab === 'courses' && <p>Courses are selected!</p>}
        
        <h4>3. Multiple conditions:</h4>
        {activeTab === 'blogs' && blogs.length > 0 && (
          <p>Showing {blogs.length} blog posts</p>
        )}

        <h4>4. Nullish rendering:</h4>
        {activeTab === 'unknown' || <p>Valid tab selected</p>}
      </div>
    </div>
  );
}

export default ConditionalRenderer;
