import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
      super(props);
      this.state = { chats: [], loading: true, activeChatId: undefined };
  }

  componentDidMount() {
    this.loadChats();
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
                    <tr key={p.id} onClick={() => this.setState({ activeChatId: p.id })}>
                        <td>id: {p.id}</td>
                        <td>From: {p.from}</td>
                  <td>To: {p.to}</td>
                  </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
          : this.renderForecastsTable(this.state.chats);

      const p = this.state.activeChatId && this.state.chats.find(l => l.id === this.state.activeChatId)

    return (
      <div>
            <h1 id="tabelLabel" >Messages</h1>

            {p && <div>
                <button onClick={() => this.setState({ activeChatId: undefined })}>BACK</button>
                <br/>   
                {p.from} to {p.to}: {p.messages && p.messages.map(c =>
                    <div>{c.text}<button onClick={() => this.deleteMessage(p.id, c.id)}>DELETE</button>  </div>
                )}
                    <input id={"text" + p.id} />    <button onClick={() => this.sendMessage(p.id)}>SEND</button>
                <button onClick={() => this.deleteChat(p.id)}>DELETE CHAT</button>

                </div>
                }
            {!p && <div>
                <input id={"from"} /> to <input id={"to"} />    <button onClick={() => this.createChat()}>CREATE CHAT</button>
                {contents}
            </div>
            }
      </div>
    );
  }

    async loadMessages(id) {
        const response = await fetch('/api/messages/all?chatId=' + id, {
            method: 'GET',

            headers: {
                'Content-Type': 'application/json'
            }
        });
        const data = await response.json();
        this.setState({
            chats: this.state.chats.map(l => {
                if (l.id !== id) return l;
                return {
                    ...l,
                    messages: data
                }
            }), loading: false
        });
    }

    async loadChats() {
      const response = await fetch('/api/chats/all', {
          method: 'GET',

          headers: {
              'Content-Type': 'application/json'
          }
        });
        const data = await response.json();
        data.forEach(l => this.loadMessages(l.id));
    this.setState({ chats: data, loading: false });
    }

    async createChat() {
        const response = await fetch('/api/chats', {
            method: 'POST',
            body: JSON.stringify({
                from: document.getElementById('from').value,
                to: document.getElementById('to').value
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const data = await response.json();
        console.log(data);
        this.setState({
            chats: [...this.state.chats, {
                ...data,
                messages: []
            }], loading: false
        });
    }


    async sendMessage(chatId) {
        const response = await fetch('/api/messages/', {
            method: 'POST',
            body: JSON.stringify({
                chatId: chatId,
                text: document.querySelector("#text" + chatId).value
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const data = await response.json();
        this.setState({
            chats: this.state.chats.map(l => {
                if (l.id !== chatId) return l;
                return {
                    ...l,
                    messages: [...l.messages, data]
                }
            }), loading: false
        });
        console.log(data);
        //this.setState({ forecasts: data, loading: false });
    }


    async deleteChat(chatId) {
        const response = await fetch('/api/chats/?id=' + chatId, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        this.setState({
            chats: this.state.chats.filter(l => l.id !== chatId)});
        //this.setState({ forecasts: data, loading: false });
    }

    async deleteMessage(chatId, messageId) {
        const response = await fetch('/api/messages/?messageId=' + messageId, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        this.setState({
            chats: this.state.chats.map(l => {
                if (l.id !== chatId) return l;
                return {
                    ...l,
                    messages: l.messages.filter(l => l.id != messageId)
                }
            }), loading: false
        });
        //this.setState({ forecasts: data, loading: false });
    }
}
