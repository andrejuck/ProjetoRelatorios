import React, { Component } from 'react';
import { Link } from "react-router";

class App extends Component {
    render() {
        return (
            <div className="ui">
                <div className="navbar">
                    <div className="navbar container">
                        <div className="itens">
                            <Link to="/home">
                                <i className="fa small fa-home"></i>
                                Visão Geral
                            </Link>
                            <Link to="/cadastros" >
                                <i className="fa small fa-edit"></i>
                                Cadastros
                            </Link>
                            <Link to="/receitas" >
                                <i className="fa small fa-plus"></i>
                                Receita
                                </Link>
                            <Link to="/despesas" >
                                <i className="fa small fa-minus"></i>
                                Despesas
                            </Link>
                        </div>

                    </div>
                </div>
                <div className="ui">
                    { this.props.children }                    
                </div>

            </div>
        );
    }
}

export default App;
