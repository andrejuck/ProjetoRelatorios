import React, { Component } from 'react';
import PageTitle from './micro-components/PageTitle';
import Card from './micro-components/Card';

export default class Home extends Component {
   
    render() {
        return (
            <div className="ui container">
                <PageTitle pageName="Visão Geral" />
                <div className="row">
                    <div className="four wide column">
                        <Card>
                            
                        </Card>
                    </div>
                    <div className="four wide column">
                        {/* <Card header="Card com botão" body="Lorem ipsum egestas quisque vulputate mollis curabitur dapibus etiam ac class donec" button={button} /> */}
                    </div>
                    <div className="four wide column">
                        <div className="card">
                            <div className="card-header">
                                Botão cheio
                            </div>
                            <div className="card-body">
                                Lorem ipsum egestas quisque vulputate mollis curabitur dapibus etiam ac class donec
                                    </div>
                            <div className="card-footer full">
                                <button className="btn primary">
                                    <i className="fa fa-pencil"></i>
                                    Botão
                                </button>
                            </div>
                        </div>
                    </div>
                    <div className="four wide column">
                        <div className="card">
                            <div className="card-body">
                                Card Apenas com Body
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
const button = (
    <button className="btn primary">Teste</button>
)