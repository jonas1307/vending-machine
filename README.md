<div id="top"></div>

# Vending Machine

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

[![Product Name Screen Shot][product-screenshot]](https://example.com)

<!-- ABOUT THE PROJECT -->

## About The Project

This is a vending machine emulator built using .NET Core. It simulates inserting coins, selecting a product, and getting the corresponding change. Validations such as product availability, change availability, and validating the inserted amount of money are also implemented in this solution. When a user buys a product, the machine stores the coins on a stack and uses them later for providing change.

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

- [.Net 6](https://docs.microsoft.com/en-us/dotnet/core/introduction)
- [Bootstrap](https://getbootstrap.com)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

To get a local copy up and running follow these simple example steps.

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) or later

### Installation (for Visual Studio 2022 or later)

1. Clone the repository on your machine
2. Open the file `VendingMachine.sln` using Visual Studio 2022
3. Build the solution using `CTRL+Shift+B` to check for errors (and also restore Nuget packages)
4. Run the unit tests using `CTRL+R, A`
5. Right-click on the project `VendingMachine.Web` and set it as the startup project
6. Hit `F5` and you should get the project up and running

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ROADMAP -->

## Roadmap

- [x] Create an algorithm for selecting the change
- [x] Code MachineCoinStack and UserCoinStack classes
- [x] Code Product and ProductGrid classes
- [x] Create a ChangeService
- [x] Create MachineService
- [x] Unit tests
- [x] Web interface for basic operation of the machine
- [x] Show the amount of products available to the user
- [x] Disable buttons for buying out of stock products
- [ ] Optimize application for smaller screens (responsiveness)
- [ ] Add Docker support
- [ ] Add Github Actions support
- [ ] Publish the application in a cloud service for having a live preview

See the [open issues](https://github.com/jonas1307/vending-machine/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->

## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTACT -->

## Contact

Jonas Amorim - [@jonas1307](https://twitter.com/jonas1307) - jonasamorim [dot] dev [at] gmail [dot] com

Project Link: [https://github.com/jonas1307/vending-machine](https://github.com/jonas1307/vending-machine)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->

[contributors-shield]: https://img.shields.io/github/contributors/jonas1307/vending-machine.svg?style=for-the-badge
[contributors-url]: https://github.com/jonas1307/vending-machine/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/jonas1307/vending-machine.svg?style=for-the-badge
[forks-url]: https://github.com/jonas1307/vending-machine/network/members
[stars-shield]: https://img.shields.io/github/stars/jonas1307/vending-machine.svg?style=for-the-badge
[stars-url]: https://github.com/jonas1307/vending-machine/stargazers
[issues-shield]: https://img.shields.io/github/issues/jonas1307/vending-machine.svg?style=for-the-badge
[issues-url]: https://github.com/jonas1307/vending-machine/issues
[license-shield]: https://img.shields.io/github/license/jonas1307/vending-machine.svg?style=for-the-badge
[license-url]: https://github.com/jonas1307/vending-machine/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/jonas-amorim
[product-screenshot]: images/screenshot.png
