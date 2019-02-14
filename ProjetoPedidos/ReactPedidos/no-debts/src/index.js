import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import './css/reset.css';
import './css/media-queries.css';
import './css/grid.css';
import './css/main.css';
import App from './App';
import Login from './components/Login';
import * as serviceWorker from './serviceWorker';
import { Router, Route, browserHistory } from 'react-router';

ReactDOM.render(
    (
        <Router history={browserHistory}>
            <Route path="/" component={Login}></Route>
            <Route path="/Home" component={App}></Route>
        </Router>
    ), 
    document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
