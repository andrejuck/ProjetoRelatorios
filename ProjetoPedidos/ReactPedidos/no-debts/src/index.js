import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import "../node_modules/font-awesome/css/font-awesome.min.css";
import './css/reset.css';
import './css/media-queries.css';
import './css/main.css';
import App from './App';
import Login from './components/Login';
import Cadastro from './components/Cadastro';
import Receita from './components/Receita';
import Despesa from './components/Despesa';
import Home from './components/Home';
import * as serviceWorker from './serviceWorker';
import { Router, Route, browserHistory, IndexRoute } from 'react-router';

ReactDOM.render(
    (
        <Router history={browserHistory}>
            <Route path="/" component={Login}></Route>
            <Route path="/home" component={App}>
                <IndexRoute component={Home}></IndexRoute>
                <Route path="/cadastros" component={Cadastro}></Route>
                <Route path="/receitas" component={Receita}></Route>
                <Route path="/despesas" component={Despesa}></Route>
            </Route>
        </Router>
    ), 
    document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
