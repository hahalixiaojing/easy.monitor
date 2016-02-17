CREATE TABLE `monitor_metadata` (
	`servcie_name` varchar(100) NULL,
	`ip` varchar(20) NULL,
	`api_url` varchar(300) NULL,
	`api_url_hashcode` int NULL,
	`base_api_url` varchar(300) NULL DEFAULT 0,
	`base_api_url_hashcode` int NULL,
	`api_path` varchar(50) NULL,
	`frequency` int NULL,
	`max_response_time` int NULL,
	`mini_response_time` int NULL,
	`average_response_time` double(10,2) NULL,
	`stat_time` datetime not null,
	INDEX `time` (`stat_time`),
	INDEX `base_api_url_hashcode` (`base_api_url_hashcode`),
	INDEX `ip` (`ip`),
	INDEX `servcie_name` (`servcie_name`),
	INDEX `api_url_hashcode` (`api_url_hashcode`)
);