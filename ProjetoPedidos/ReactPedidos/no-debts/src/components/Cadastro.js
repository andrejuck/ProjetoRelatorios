import React, { Component } from 'react';
import PageTitle from './micro-components/PageTitle';


export default class Cadastro extends Component {
    render() {
        return (
            <div className="ui container">
                <PageTitle pageName="Cadastro" />
            </div>
        );
    }
}