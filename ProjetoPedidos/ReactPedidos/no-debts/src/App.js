import React, { Component } from 'react';
import { Link } from "react-router";

class App extends Component {
    render() {
        return (
            <div className="ui">
                {/* <header className="header">

                </header> */}
                <aside className="navbar">
                    <div className="navbar container">
                        <div className="menu-header">
                            <h1 className="header">
                                <Link to="/home">
                                    No Debts!
                                </Link>
                            </h1>
                            <i className="fa fa-bars white"></i>
                        </div>
                        <div className="separator">
                            <hr></hr>
                        </div>
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
                </aside>
                <div className="content">
                    {this.props.children}
                </div>

            </div>
        );
    }
}

export default App;
