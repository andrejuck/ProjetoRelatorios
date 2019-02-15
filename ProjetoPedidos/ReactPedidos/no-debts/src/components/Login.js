import React, { Component } from 'react';

export default class Login extends Component {

    constructor() {
        super();
        this.state = { msg: '' }
    }

    envia(event) {
        event.preventDefault();

        const requestInfo = {
            method: 'POST',
            body: JSON.stringify({ login: this.login.value, password: this.password.value }),
            headers: new Headers({
                'Content-type': 'application/json'
            })
        }

        fetch('https://localhost:44326/api/login/Authenticate', requestInfo)
            .then(response => {
                if (response.ok){
                    console.log(response);
                    return response.text();
                }
                else {
                    this.setState({ msg: "Usuário ou Senha Inválidos" })
                }
            })
            .then(response => { console.log(response) })
    }

    render() {
        return (
            <div className="ui">
                <div className="ui container ">
                    <form className="login" onSubmit={this.envia.bind(this)}>
                        <div className="row">
                            <div className="column">
                                <h3 className="header primary">Login</h3>
                            </div>
                        </div>
                        <div className="row">
                            <div className="column">
                                <hr className="separator" />
                            </div>
                        </div>
                        <span>{this.state.msg}</span>
                        <div className="row">
                            <div className="column">
                                <label> Username: </label>
                                <input type="text" ref={(input) => this.login = input}></input>
                            </div>
                        </div>

                        <div className="row">
                            <div className="column">
                                <label> Password: </label>
                                <input type="password" ref={(input) => this.password = input}></input>
                            </div>
                        </div>

                        <div className="row">
                            <div className="column">
                                <button className="btn primary">Entrar</button>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        );
    }
}