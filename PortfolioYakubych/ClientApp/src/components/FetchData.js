import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { posts: [], loading: true };
  }

  componentDidMount() {
    this.loadPosts();
  }

  renderForecastsTable(posts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Text</th>
          </tr>
        </thead>
        <tbody>
                {posts.map(p =>
                    <tr key={p.id}>
                        <td>id: {p.id}</td>
                        <td>Title: {p.title}</td>
                  <td>Text: {p.text}</td>
                  <td>Comments: {p.comments && p.comments.map(c =>
                      <div>{c.text}<button onClick={() => this.deleteComment(p.id, c.id)}>DELETE</button>  </div>
                        )}
                            <input id={"comm" + p.id} />    <button onClick={() => this.sendComment(p.id)}>SEND</button>
                        </td>
                        <button onClick={() => this.deletePost(p.id)}>DELETE POST</button>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderForecastsTable(this.state.posts);

    return (
      <div>
            <h1 id="tabelLabel" >Posts</h1>
            <input id={"title"} /> <input id={"text"} />    <button onClick={() => this.createPost()}>SEND</button>

        {contents}
      </div>
    );
  }

    async loadComments(id) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/comments/all?postId=' + id, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            }
        });
        const data = await response.json();
        this.setState({
            posts: this.state.posts.map(l => {
                if (l.id !== id) return l;
                return {
                    ...l,
                    comments: data
                }
            }), loading: false
        });
    }

    async loadPosts() {
      const token = await authService.getAccessToken();
      const response = await fetch('/api/blogposts/all', {
          method: 'GET',
          headers: {
              'Authorization': `Bearer ${token}`,
              'Content-Type': 'application/json'
          }
    });
        const data = await response.json();
        data.forEach(l => this.loadComments(l.id));
    this.setState({ posts: data, loading: false });
    }

    async createPost() {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/blogposts', {
            method: 'POST',
            body: JSON.stringify({
                title: document.getElementById('title').value,
                text: document.getElementById('text').value
            }),
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            }
        });
        const data = await response.json();
        console.log(data);
        this.setState({
            posts: [...this.state.posts, {
                ...data,
                comments: []
            }], loading: false
        });
    }


    async sendComment(postId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/comments/?postId=' + postId, {
            method: 'POST',
            body: JSON.stringify({
                text: document.querySelector("#comm" + postId).value
            }),
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            }
        });
        const data = await response.json();
        this.setState({
            posts: this.state.posts.map(l => {
                if (l.id !== postId) return l;
                return {
                    ...l,
                    comments: [...l.comments, data]
                }
            }), loading: false
        });
        console.log(data);
        //this.setState({ forecasts: data, loading: false });
    }


    async deletePost(postId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/blogposts/?id=' + postId, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            }
        });
        this.setState({
            posts: this.state.posts.filter(l => l.id !== postId)});
        //this.setState({ forecasts: data, loading: false });
    }

    async deleteComment(postId, commentId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/comments/?commentId=' + commentId, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            }
        });
        this.setState({
            posts: this.state.posts.map(l => {
                if (l.id !== postId) return l;
                return {
                    ...l,
                    comments: l.comments.filter(l => l.id != commentId)
                }
            }), loading: false
        });
        //this.setState({ forecasts: data, loading: false });
    }
}
