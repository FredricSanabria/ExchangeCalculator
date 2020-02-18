import React, { Component } from 'react';
import Currencies from './currencies';

class Converter extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <div>
                    <Currencies />
                </div>
                <div>
                    <Currencies />
                </div>
            </div>
        );
    }
}

export default Converter;