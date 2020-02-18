import React, { Component } from 'react'; 

class Currencies extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            currencies: []
        }
    }

    // TODO: cacha currencies
    componentDidMount() {
        fetch("https://localhost:44323/api/swea/GetCurrencies")
            .then(res => res.json())
            .then(
                (result) => {
                this.setState({
                    isLoaded: true,
                    blog: result.blog,
                    currencies: result
                });
                },
                (error) => {
                // TODO: log
                this.setState({
                    isLoaded: true,
                    error
                });
            }
        )
    }
    render() {
        const { error, isLoaded, currencies } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading currencies...</div>;;
        } else {
            return (
                <select>
                    {currencies.map(currency => 
                        <option value="{currency.id}">{currency.name}</option>
                    )}
                </select>
            );
        }
    }
}

export default Currencies;