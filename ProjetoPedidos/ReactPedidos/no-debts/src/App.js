import React, { Component } from 'react';
import Login from './components/Login';
import './css/reset.css';
import './css/media-queries.css';
import './css/grid.css';
import './css/main.css';

class App extends Component {
    render() {
        return (
            <div className="ui">
                <div className="ui container ">
                    <Login />
                </div>
            </div>
        );
    }
}

export default App;
