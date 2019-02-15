import React, { Component } from 'react';

class App extends Component {
    render() {
        return (
            <div className="ui">
                <div className="navbar">
                    <div className="navbar container">
                        <div className="navbar menu">
                            <div className="itens">
                                <img className="image" alt="" src={require("./resources/logo.png")}></img>
                                <a href="" >Home</a>
                            </div>

                        </div>
                    </div>
                </div>
                <div className="ui container">

                </div>
            </div>
        );
    }
}

export default App;
