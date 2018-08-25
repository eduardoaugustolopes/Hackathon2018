import React from 'react';
import Radium from 'radium';

const Sidebar = () => (
    <div className="docs-sidebar off-canvas-sidebar" id="sidebar">
        <div className="docs-brand">
            <a href="/" style={styles.linkHome}>
                <span className="text-bold" href="/" style={styles.title}>+Care</span>
            </a>
        </div>
        <div className="docs-nav">
            <div className="accordion-container">
                <div className="accordion">
                    <input id="accordion-cadastros" type="checkbox" name="docs-accordion-checkbox" hidden />
                    <ul className="menu menu-nav">
                        <li className="menu-item">
                            <a href="/agendamentos" key="agendamentos" style={styles.link}>Agendamentos</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
);

const styles = {
    title: {
        fontSize: '20px',
        color: '#023d44'
    },
    link: {
        boxShadow: 'none',
        ':hover': {
            boxShadow: '0px 0px 1px 2px #023d44'
        }
    },
    linkHome: {
        boxShadow: 'none',
        textDecoration: 'none'
    }
};

export default Radium(Sidebar)