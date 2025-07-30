import { blogs } from '../data/data';

function BlogDetails() {
  const content = blogs.map((blog) => (
    <div key={blog.id}>
      <h2>{blog.title}</h2>
      <h4>{blog.author}</h4>
      <p>{blog.content}</p>
    </div>
  ));

  return (
    <div>
      <div>
        <div className="v1">
          <h1>Blog Details</h1>
          {content}
        </div>
      </div>
    </div>
  );
}

export default BlogDetails;
