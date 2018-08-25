import React from 'react';
import Radium from 'radium';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Agendamentos from './Usuario/Agendamentos';

const Content = () => (
    <div className="off-canvas-content" style={styles.content}>
        <BrowserRouter>
            <Switch>
                <Route path="/agendamentos" component={Agendamentos}></Route>
            </Switch>
        </BrowserRouter>
    </div>
);

const styles = {
    content: {
        margin: '100px 100px 50px 0px',
        height: '100vh',
        '@media (max-width: 967px)': {
            margin: '90px 10px 10px 10px'
        }
    }
};

export default Radium(Content);