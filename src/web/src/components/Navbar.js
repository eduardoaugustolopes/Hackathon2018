import React from 'react';
import Radium from 'radium';

const Navbar = () => (
    <div className="docs-navbar" style={styles.navbar}>
        <a href="/">
            <span className="hide-lg text-bold" style={styles.title}>+CARE</span>
        </a>
        <a className="off-canvas-toggle btn btn-link btn-action" key="menu" style={styles.link} href="#sidebar">
            <i className="icon icon-menu"></i>
        </a>
    </div>
);

const styles = {
    navbar: {
        background: '#0084C1',
        left: 0,
        zIndex: 300,
        '@media (max-width: 967px)': {
            zIndex: 100
        }
    },
    title: {
        color: '#fff',
        position: 'absolute',
        top: '27%',
        marginLeft: '30px',
        fontSize: '20px'
    },
    link: {
        color: '#fff',
        boxShadow: 'none',
        ':hover': {
            boxShadow: '0px 0px 1px 2px #00a859'
        }
    },
    icon: {
        fontSize: '25px',
    }
};

export default Radium(Navbar);