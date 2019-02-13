import React, { Component } from 'react';

export default class Login extends Component {
    render() {
        return (
            <form className="login">
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
                <div className="row">
                    <div className="column">
                        <label> Username: </label>
                        <input type="text"></input>
                    </div>
                </div>

                <div className="row">
                    <div className="column">
                        <label> Password: </label>
                        <input type="password"></input>
                    </div>
                </div>

                <div className="row">
                    <div className="column">
                        <button className="btn primary">Entrar</button>
                    </div>
                </div>

            </form>
        );
    }
}