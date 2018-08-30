import React, { Component } from 'react';
import Hero from './Hero';

class Heroes extends Component {
    state = { heroes: [] };

    componentDidMount() {
        fetch('/api/heroes').then(result => result.json()).then(json => {
            this.setState({ heroes: json });
        })
    };

    render() {
        return (
            <div>
                <ul className="heroes">
                    {this.state.heroes.map(hero => {
                        return <Hero hero={hero} />;
                    })}
                </ul>
                <div className="editarea">
                    {
                        // Edit form
                    }
                </div>
            </div>
        );
    };
}

export default Heroes;