import PropTypes from 'prop-types';
import React, { Component } from 'react';
import {
    Button,
    Checkbox,
    Grid,
    Header,
    Icon,
    Image,
    Menu,
    Segment,
    Sidebar,
} from 'semantic-ui-react';

const VerticalSidebar = ({ animation, direction, visible }) => (
    <Sidebar
        as={Menu}
        animation={animation}
        direction={direction}
        icon='labeled'
        inverted
        vertical
        visible={visible}
        width='thin'
        className="two wide"
    >
        <Menu.Item as='a'>
            <Icon name='home' />
            Home
      </Menu.Item>
        <Menu.Item as='a'>
            <Icon name='gamepad' />
            Games
      </Menu.Item>
        <Menu.Item as='a'>
            <Icon name='camera' />
            Channels
      </Menu.Item>
    </Sidebar>
)

VerticalSidebar.propTypes = {
    animation: PropTypes.string,
    direction: PropTypes.string,
    visible: PropTypes.bool,
}

export default class MenuLateral extends Component {

    state = {
        animation: 'overlay',
        direction: 'left',
        dimmed: false,
        visible: false,
    }

    handleAnimationChange = animation => () =>
        this.setState({ animation, visible: !this.state.visible })

    handleDimmedChange = (e, { checked }) => this.setState({ dimmed: checked })

    handleDirectionChange = direction => () => this.setState({ direction, visible: false })

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render() {
        const { animation, dimmed, direction, visible } = this.state
        const vertical = direction === 'bottom' || direction === 'top'
        return (
            <div>
                <Sidebar.Pushable as={Segment}>
                    <VerticalSidebar animation={animation} direction={direction} visible={visible} />
                    <Sidebar.Pusher dimmed={dimmed && visible}>
                        <Segment className="two wide" basic>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            <Header as='h3'>Application Content</Header>
                            
                        </Segment>
                    </Sidebar.Pusher>
                </Sidebar.Pushable>
                <Button disabled={vertical} onClick={this.handleAnimationChange('uncover')}>
                    Uncover
                </Button>
            </div>
        )
    }
}